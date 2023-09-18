using APIDesafioBackEndIndustriall.Data;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioBackEndIndustriall.Services;

public class EventUserService(IndustriallContext context): Service<EventUser>(context)
{
    public override async Task<List<EventUser>> GetAsync() =>
        await context.EventsUsers.ToListAsync();

    public override async Task<EventUser?> GetAsync(int id) =>
        await context.EventsUsers.FirstOrDefaultAsync(x => x.Id ==id);
    
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
    
    public List<User> GetUsers(Event Event)
    {
        var usersIds = context.EventsUsers
            .Where(x => x.EventId == Event.Id)
            .Select(x => x.UserId)
            .ToList();

        var users = context.Users
            .Where(e => usersIds.Contains(e.Id))
            .ToList();

        return users;
    }
    

    public override async Task RemoveAsync(EventUser EventUser)
    {
        context.EventsUsers.Remove(EventUser);
        await context.SaveChangesAsync();
    }
}