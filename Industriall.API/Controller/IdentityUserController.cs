using Industriall.API.Models;
using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;
using Industriall.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Industriall.API.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityUserController(IIdentityService userService) : ControllerBase
{

    [HttpPost("cadastro")]
    public async Task<ActionResult<UserRegisterResponse>> Register(UserRegisterRequest userRegister)
    {
        if(!ModelState.IsValid)
            return BadRequest();
        var result = await userService.RegisterUser(userRegister);
        if (result.Sucess)
            return Ok(result);
        if (result.Errors.Any()) return BadRequest(result);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest userLogin)
    {
        if(!ModelState.IsValid)
            return BadRequest();
        var result = await userService.LoginUser(userLogin);
        if (result.Sucess)
            return Ok(result);
        return Unauthorized(result);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        
        return Ok(await userService.GetAsync());
    }
    
    [HttpGet("current")]
    public async Task<IActionResult> GetUser()
    {
        var user = HttpContext.User;
        return Ok(await userService.GetAsync(HttpContext.User));
    }
    
    [HttpGet("delete")]
    public async Task<IActionResult> DeleteUser()
    {
        var user = HttpContext.User;
        if (!user.Claims.Any()) return BadRequest();
        await userService.RemoveAsync(HttpContext.User);
        return NoContent();
    }
}