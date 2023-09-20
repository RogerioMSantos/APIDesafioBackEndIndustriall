using Industriall.API.Models;
using Industriall.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Industriall.API.Data;

public class IndustriallContext(DbContextOptions<IndustriallContext> options,
        IOptions<IndustriallDatabaseSettings> insdustrialDabaseSettings)
    : DbContext(options)
{
    private readonly string _connect = insdustrialDabaseSettings.Value.ConnectionString;
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }

    public DbSet<EventUser> EventsUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connect);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Participants)
            .WithMany()
            .UsingEntity<EventUser>();
        modelBuilder.Entity<User>()
            .HasOne(u => u.IdentityUser);
    }
}