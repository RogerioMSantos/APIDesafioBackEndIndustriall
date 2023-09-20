using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;

namespace Industriall.Application.Interfaces;

public interface IIdentityService
{
    Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister);

    Task<UserLoginResponse> LoginUser(UserLoginRequest userRegister);
}