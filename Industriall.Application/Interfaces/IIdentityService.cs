using System.Security.Claims;
using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;
using Industriall.Application.Model;

namespace Industriall.Application.Interfaces;

public interface IIdentityService
{
    Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister);

    Task<UserLoginResponse> LoginUser(UserLoginRequest userRegister);

    public Task<List<ApplicationUser>> GetAsync();

    public Task<ApplicationUser> GetAsync(ClaimsPrincipal userId);

    public Task RemoveAsync(ClaimsPrincipal userId);
}