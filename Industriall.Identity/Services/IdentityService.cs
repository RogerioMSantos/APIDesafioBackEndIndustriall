using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;
using Industriall.Application.Interfaces;
using Industriall.Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Industriall.Identity.Services;

public class IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
        IOptions<JwtOptions> jwtOptions)
    : IIdentityService
{
    private JwtOptions _jwtOptions = jwtOptions.Value;
    
    public async Task<List<IdentityUser>> GetAsync()
    {
        return await userManager.Users.ToListAsync();
    }
    
    public async Task<IdentityUser> GetAsync(ClaimsPrincipal userId)
    {
        return (await userManager.GetUserAsync(userId))!;
    }
    
    public async Task RemoveAsync(ClaimsPrincipal userId)
    {
        var user = await GetAsync(userId);
        await userManager.DeleteAsync(user);
    }
    
    public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister)
    {
        var identityUser = new IdentityUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(identityUser, userRegister.Password!);

        if (result.Succeeded)
            await userManager.SetLockoutEnabledAsync(identityUser, false);

        var userRegisterResponse = new UserRegisterResponse(result.Succeeded);

        if (!result.Succeeded && result.Errors.Any())
            userRegisterResponse.AddErrors(result.Errors.Select(r => r.Description));

        return userRegisterResponse;
    }

    public async Task<UserLoginResponse> LoginUser(UserLoginRequest userLogin)
    {
        var result = await signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
        if (result.Succeeded)
            return await GenerateCredentials(userLogin.Email);

        var userLoginResponse = new UserLoginResponse(result.Succeeded);
        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                userLoginResponse.Adderror("Essa conta está bloqueada");
            else if (result.IsNotAllowed)
                userLoginResponse.Adderror("Essa conta não tem permissão para fazer login");
            else if (result.RequiresTwoFactor)
                userLoginResponse.Adderror("É necessario confirmar o login no seu e-mail");
            else
                userLoginResponse.Adderror("Usuário ou senha estão incorretos");
        }

        return userLoginResponse;
    }

    private async Task<UserLoginResponse> GenerateCredentials(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        var accessTokenClaims = await GetClaims(user!, true);
        var refreshTokenClaims = await GetClaims(user!, false);

        var dateExpirationAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dateExpirationRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = TokenGenerate(accessTokenClaims, dateExpirationAccessToken);
        var refreshToken = TokenGenerate(refreshTokenClaims, dateExpirationRefreshToken);

        return new UserLoginResponse
        (
            Sucess: true,
            accessToken:accessToken,
            refreshToken:refreshToken
        );
    }

    private string TokenGenerate(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {
        var jwt = new JwtSecurityToken(
            issuer:_jwtOptions.Issuer,
            audience:_jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: dataExpiracao,
            signingCredentials:_jwtOptions.SigningCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IList<Claim>> GetClaims(IdentityUser user, bool adicionarClaimsUsuario)
    {
        var claims = await userManager.GetClaimsAsync(user);

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (!adicionarClaimsUsuario) return claims;
        var userClaims = await userManager.GetClaimsAsync(user);
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles) claims.Add(new Claim("role", role));

        return claims;
    }
}