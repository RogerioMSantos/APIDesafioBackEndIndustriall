using System.Diagnostics.CodeAnalysis;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public String GetUsers()
    {
        return $"All users here!";
    }
    [HttpGet("{id}")]
    public String GetUser(int id)
    {
        return $"User {id} here!";
    }
    
    [HttpPost]
    public String CreateUser([FromForm]User user)
    {
        return $"user.name = {user.Name}\n" +
               $"user.password = {user.Password}!";
    }
    
    [HttpDelete("{id}")]
    public String DeleteUser(int id)
    {
        return $"Deleting user {id} here!";
    }
    
    [HttpPut("{id}")]
    public String UpdateUser(int id)
    {
        return $"Updating user {id} here!";
    }
}