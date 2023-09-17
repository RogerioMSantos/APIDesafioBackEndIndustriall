using APIDesafioBackEndIndustriall.Models;
using APIDesafioBackEndIndustriall.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService) =>
        _userService = userService;


    [HttpGet]
    public async Task<IActionResult> GetUsers() =>   Ok(await _userService.GetAsync());
    

    [HttpGet("{name}")]
    public async Task<IActionResult> GetUser(string name)
    {
        var user = await _userService.GetAsync(name);
        if (user is null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        
        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(GetUser), new {name = user.Name }, user);
    }
    
    [HttpPut("{name}")]
    public async Task<IActionResult> UpdateUser(string name, [FromBody]User user)
    {
        
        var oldUser = await _userService.GetAsync(name);
        if (oldUser is null)
        {
            return NotFound();
        }

        user.Id = oldUser.Id;

        await _userService.UpdateAsync(user);
        return NoContent();
    }
    
    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteUser(string name)
    {
        var user = await _userService.GetAsync(name);

        if (user is null)
        {
            return NotFound();
        }

        await _userService.RemoveAsync(user);
        return NoContent();
    }

    
}