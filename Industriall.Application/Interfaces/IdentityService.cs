using Industriall.Application.DTOs.Response;

namespace Industriall.Application.Interfaces;

public interface IdentityService
{
    Task<UserRegisterResponse> RegisterUser(UserRegisterResponse userRegister);
    
    Task<UserLoginResponse> LoginrUser(UserLoginResponse userRegister);
}