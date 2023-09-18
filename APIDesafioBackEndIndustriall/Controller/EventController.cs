using APIDesafioBackEndIndustriall.Models;
using APIDesafioBackEndIndustriall.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

[ApiController]
[Route("[controller]")]
public class EventController(EventService eventService
    ,UserService userService,EventUserService eventUserService) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {

        var lEvent = await eventService.GetAsync();

        foreach (var iEvent in lEvent)
        {
            
            iEvent.Participants = GetParticipants(iEvent);
        }
        return Ok(lEvent);
    }

    private List<User> GetParticipants(Event Event) => eventUserService.GetUsers(Event);



    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var nEvent = await eventService.GetAsync(id);
            
        nEvent.Participants = GetParticipants(nEvent);

        return Ok(nEvent);
    }
    
    

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event nEvent)
    {
        if (nEvent.ResponsibleId is null) return BadRequest();
        var responsible =  await GetUser((int)nEvent.ResponsibleId);

        if (responsible is null) return NotFound();
        // var participants = new List<User>();
        // foreach (var participant in nEvent.Participants)
        // {
        //     var user = await GetUser(participant.Id);
        //     if (user is null) return NotFound();
        //     participants.Add(user);
        // }

        // nEvent.Participants = participants;
        nEvent.ResponsibleId = responsible.Id;
        await eventService.CreateAsync(nEvent);
        return CreatedAtAction(nameof(GetEvent),new {id = nEvent.Id},nEvent);
    }

    private async Task<User?> GetUser(int user)
    {
        var fUser = await userService.GetAsync(user);
        
        return fUser;

    }
    

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, [FromBody]Event uEvent)
    {
        
        var oldEvent = await eventService.GetAsync(id);
        if (oldEvent is null)
        {
            return NotFound();
        }
        
        oldEvent.UpdateEvent(uEvent);
        await eventService.UpdateAsync(oldEvent);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var fEvent = await eventService.GetAsync(id);

        if (fEvent is null)
        {
            return NotFound();
        }
        
        await eventService.RemoveAsyncCascade(fEvent);
        return NoContent();
    }
}