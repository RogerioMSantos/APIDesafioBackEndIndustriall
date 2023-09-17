using APIDesafioBackEndIndustriall.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;


[ApiController]
[Route("[controller]")]
public class EventController : Microsoft.AspNetCore.Mvc.Controller
{
    // GET
    [HttpGet]
    public String GetEvents()
    {
        return $"All Events here!";
    }
    [HttpGet("{id}")]
    public String GetEvent(int id)
    {
        return $"All events here!";
    }
    
    [HttpPost]
    public String CreateEvent([FromBody]Event eventC)
    {
        return $"event.description = {eventC.Description}\n" +
               $"event.Date = {eventC.Date}\n" +
               $"event.Participants = {eventC.Participants[0]}\n" +
               $"event.Responsable = {eventC.Responsable}\n" +
               $"event.Title = {eventC.Title}\n";
    }
    
    [HttpDelete("{id}")]
    public String DeleteEvent(int id)
    {
        return $"Deleting event {id} here!";
    }
    
    [HttpPut("{id}")]
    public String UpdateEvent(int id)
    {
        return $"Updating event {id} here!";
    }
}