using Industriall.API.Data;
using Industriall.API.Models;
using Industriall.Identity.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Industriall.API.Services;

public class EventService(IndustriallContext context) : Service<Event>(context)
{
    public override async Task<List<Event>> GetAsync()
    {
        return await context.Events.ToListAsync();
    }

    public override async Task<Event?> GetAsync(int id)
    {
        return await context.Events.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task RemoveAsync(Event eEvent)
    {
        context.Events.Remove(eEvent);
        await context.SaveChangesAsync();
    }


    public async Task RemoveAsyncCascade(Event eEvent)
    {
        context.Events.Remove(eEvent);
        await context.SaveChangesAsync();
    }
}