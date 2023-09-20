using Industriall.API.Models;
using Industriall.API.Services;
using Industriall.Application.Interfaces;
using Industriall.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Industriall.API.Controller;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService, IIdentityService identityService):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers() =>   Ok(await userService.GetAsync());
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await userService.GetAsync(id);
        if (user is null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var identityId = await identityService.GetAsync(HttpContext.User);
        user.IdentityUser = identityId;
        await userService.CreateAsync(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id }, user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody]User user)
    {
        
        var oldUser = await userService.GetAsync(id);
        if (oldUser is null)
        {
            return NotFound();
        }
        
        oldUser.UpdateUser(user);
        await userService.UpdateAsync(oldUser);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await userService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }
        
        await userService.RemoveAsync(user);
        return NoContent();
    }
}