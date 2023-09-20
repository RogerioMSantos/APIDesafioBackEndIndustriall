using Industriall.API.Models;
using Industriall.Application.DTOs.Request;
using Industriall.Application.DTOs.Response;
using Industriall.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Industriall.API.Controller;

[ApiController]
[Route("[controller]")]
public class UserController(IIdentityService userService) : ControllerBase
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
    
    
    // [HttpGet]
    // public async Task<IActionResult> GetUsers()
    // {
    //     return Ok(await userService.GetAsync());
    // }


    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetUser(int id)
    // {
    //     var user = await userService.GetAsync(id);
    //     if (user is null) return NotFound();
    //
    //     return Ok(user);
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> CreateUser([FromBody] User user)
    // {
    //     await userService.CreateAsync(user);
    //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    // {
    //     var oldUser = await userService.GetAsync(id);
    //     if (oldUser is null) return NotFound();
    //
    //     oldUser.UpdateUser(user);
    //     await userService.UpdateAsync(oldUser);
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteUser(int id)
    // {
    //     var user = await userService.GetAsync(id);
    //
    //     if (user is null) return NotFound();
    //
    //     await userService.RemoveAsync(user);
    //     return NoContent();
    // }
}