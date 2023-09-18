using APIDesafioBackEndIndustriall.Data;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioBackEndIndustriall.Services;

public class UserService(IndustriallContext context)
{
    public async Task<List<User>> GetAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetAsync(int id) =>
        await context.Users.FirstOrDefaultAsync(x => x.Id ==id);

    public async Task CreateAsync(User user)
    {
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}