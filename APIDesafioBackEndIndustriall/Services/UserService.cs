using APIDesafioBackEndIndustriall.Data;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioBackEndIndustriall.Services;

public class UserService(IndustriallContext context)
{
    public async Task<List<User>> GetAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetAsync(string name) =>
        await context.Users.FirstOrDefaultAsync(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public async Task CreateAsync(User newBook)
    {
        await context.AddAsync(newBook);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User updatedBook)
    {
        context.Update(updatedBook);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }


}