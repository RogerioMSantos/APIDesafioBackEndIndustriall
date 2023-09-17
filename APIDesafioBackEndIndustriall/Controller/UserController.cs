using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

public class UserController : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("/users")]
    public String GetUsers()
    {
        return $"All users here!";
    }
    [HttpGet]
    [Route("/users/{id}")]
    public String GetUser(int id)
    {
        return $"User {id} here!";
    }
    
    [HttpPost]
    [Route("/users/")]
    public String CreateUser()
    {
        return $"Create user here!";
    }
    
    [HttpDelete]
    [Route("/users/{id}")]
    public String DeleteUser(int id)
    {
        return $"Deleting user {id} here!";
    }
    
    [HttpPut]
    [Route("/users/{id}")]
    public String UpdateUser(int id)
    {
        return $"Updating user {id} here!";
    }
}