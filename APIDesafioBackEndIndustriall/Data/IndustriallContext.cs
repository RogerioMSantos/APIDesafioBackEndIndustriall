using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace APIDesafioBackEndIndustriall.Data;

public class IndustriallContext(DbContextOptions<IndustriallContext> options,
        IOptions<IndustriallDatabaseSettings> insdustrialDabaseSettings)
    : DbContext(options)
{
    private readonly string _connect = insdustrialDabaseSettings.Value.ConnectionString;
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connect);
    }
}