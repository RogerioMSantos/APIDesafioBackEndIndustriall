using APIDesafioBackEndIndustriall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace APIDesafioBackEndIndustriall.Data;

public class IndustriallContext : DbContext
{
    private readonly string _connect;
    public IndustriallContext(DbContextOptions<IndustriallContext> options,
        IOptions<IndustriallDatabaseSettings> insdustrialDabaseSettings) : base(options)
    {
        _connect = insdustrialDabaseSettings.Value.ConnectionString;
        Console.Out.WriteLine(_connect);
        Console.Out.WriteLine(new string('*',50));
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connect);
    }
}