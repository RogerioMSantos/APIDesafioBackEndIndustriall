using System.Security.Claims;
using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;
using Microsoft.AspNetCore.Identity;

namespace Industriall.Application.Interfaces;

public interface IIdentityService
{
    Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister);

    Task<UserLoginResponse> LoginUser(UserLoginRequest userRegister);

    public Task<List<IdentityUser>> GetAsync();

    public Task<IdentityUser> GetAsync(ClaimsPrincipal userId);

    public Task RemoveAsync(ClaimsPrincipal userId);
}