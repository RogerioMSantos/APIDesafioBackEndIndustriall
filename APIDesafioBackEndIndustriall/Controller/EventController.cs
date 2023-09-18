using APIDesafioBackEndIndustriall.Models;
using APIDesafioBackEndIndustriall.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioBackEndIndustriall.Controller;

[ApiController]
[Route("[controller]")]
public class EventController(EventService eventService,UserController userController) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<IActionResult> GetEvents() =>   Ok(await eventService.GetAsync());
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var nEvent = await eventService.GetAsync(id);
        if (nEvent is null) return NotFound();

        return Ok(nEvent);
    }
    
    

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event nEvent)
    {
        var responsable = await GetUser(nEvent.Responsable!);
        var participants = new List<User>();
        foreach (var participant in nEvent.Participants)
        {
            participants.Add(await GetUser(participant));
        }

        nEvent.Participants = participants;
        nEvent.Responsable = responsable;
        await eventService.CreateAsync(nEvent);
        return CreatedAtAction(nameof(GetEvent), new {id = nEvent.Id }, nEvent);
    }

    private async Task<User> GetUser(User user)
    {
        using (var httpCliente = new HttpClient())
        {
            var responsableResponse = await userController.GetUser(user.Id);
            var responsableResult = responsableResponse as ObjectResult;
            Task<User>? responsableUser = null;
            if (responsableResult != null && responsableResult.StatusCode == 200)
            {
                responsableUser = responsableResult.Value as Task<User>;
            }

            return await responsableUser!;
        }
        
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
        
        await eventService.RemoveAsync(fEvent);
        return NoContent();
    }
}