using Industriall.API.Data;
using Industriall.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Industriall.API.Services;

public class UserService(IndustriallContext context) : Service<User>(context)
{
    public override async Task<List<User>> GetAsync()
    {
        return await context.Users.ToListAsync();
    }

    public override async Task<User?> GetAsync(int id)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task RemoveAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}