using APIDesafioBackEndIndustriall.Data;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioBackEndIndustriall.Services;

public class EventService(IndustriallContext context) : Service<Event>(context)
{
    public override async Task<List<Event>> GetAsync() =>
        await context.Events.ToListAsync();

    public override async Task<Event?> GetAsync(int id) =>
        await context.Events.FirstOrDefaultAsync(x => x.Id ==id);

    public override async Task RemoveAsync(Event eEvent)
    {
        context.Events.Remove(eEvent);
        await context.SaveChangesAsync();
    }


    public async Task RemoveAsyncCascade(Event eEvent)
    {
        await RemoveAsyncEventoUsers(eEvent);
        context.Events.Remove(eEvent);
        await context.SaveChangesAsync();
    }
    
    private async Task RemoveAsyncEventoUsers(Event eEvent)
    {
        var enventUsers = context.EventsUsers.Where(eu => eu.EventId == eEvent.Id).ToList();
        context.EventsUsers.RemoveRange(enventUsers);
        await context.SaveChangesAsync();
    }
}