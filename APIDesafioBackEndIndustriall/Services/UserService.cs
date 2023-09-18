using APIDesafioBackEndIndustriall.Data;
using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioBackEndIndustriall.Services;

public class UserService(IndustriallContext context):Service<User>(context)
{
    public override async Task<List<User>> GetAsync() =>
        await context.Users.ToListAsync();

    public override async Task<User?> GetAsync(int id) =>
        await context.Users.FirstOrDefaultAsync(x => x.Id ==id);

    public override async Task RemoveAsync(User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}