using APIDesafioBackEndIndustriall.Models;
using APIDesafioBackEndIndustriall.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : Microsoft.AspNetCore.Mvc.Controller
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
    public async Task<IActionResult> CreateUser([FromForm] User user)
    {
        
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