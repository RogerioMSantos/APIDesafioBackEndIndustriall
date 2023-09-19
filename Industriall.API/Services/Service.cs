using Industriall.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Industriall.API.Services;

public abstract class Service<T>(DbContext context)
{
    public abstract Task<List<T>> GetAsync();

    public abstract Task<T?> GetAsync(int id);

    public async Task CreateAsync(T item)
    {
        await context.AddAsync(item!);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T item)
    {
        context.Update(item!);
        await context.SaveChangesAsync();
    }

    public abstract Task RemoveAsync(T eEvent);
}