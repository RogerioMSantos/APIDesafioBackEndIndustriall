using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Industriall.Data.Models;


namespace Industriall.Identity.Data;

public class IdentityDataContext(DbContextOptions<IdentityDataContext> options,
    IOptions<IndustriallDatabaseSettings> insdustrialDabaseSettings) : IdentityDbContext
{
    private readonly string _connect = insdustrialDabaseSettings.Value.ConnectionString;
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connect);
    }
}