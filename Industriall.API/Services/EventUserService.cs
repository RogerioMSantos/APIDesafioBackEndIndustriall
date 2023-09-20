using Industriall.API.Data;
using Industriall.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Industriall.API.Services;

public class EventUserService(IndustriallContext context) : Service<EventUser>(context)
{
    public override async Task<List<EventUser>> GetAsync()
    {
        return await context.EventsUsers.ToListAsync();
    }

    public override async Task<EventUser?> GetAsync(int id)
    {
        return await context.EventsUsers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public List<Event> GetEvents(User user)
    {
        var eventIds = context.EventsUsers
            .Where(x => x.UserId == user.Id)
            .Select(x => x.EventId)
            .ToList();

        var events = context.Events
            .Where(e => eventIds.Contains(e.Id))
            .ToList();

        return events;
    }

    public List<User> GetUsers(Event @event)
    {
        var usersIds = context.EventsUsers
            .Where(x => x.EventId == @event.Id)
            .Select(x => x.UserId)
            .ToList();

        var users = context.Users
            .Where(e => usersIds.Contains(e.Id))
            .ToList();

        return users;
    }


    public override async Task RemoveAsync(EventUser eventUser)
    {
        context.EventsUsers.Remove(eventUser);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsyncEventoUsers(Event eEvent)
    {
        var enventUsers = context.EventsUsers.Where(eu => eu.EventId == eEvent.Id).ToList();
        context.EventsUsers.RemoveRange(enventUsers);
        await context.SaveChangesAsync();
    }
}