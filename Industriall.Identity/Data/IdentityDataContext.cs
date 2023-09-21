using Industriall.Application.Model;
using Industriall.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Industriall.Identity.Data;

public class IdentityDataContext(DbContextOptions<IdentityDataContext> options,
    IOptions<IndustriallDatabaseSettings> industrialDebaseSettings) : IdentityDbContext<ApplicationUser>(options)
{
    private readonly string _connect = industrialDebaseSettings.Value.ConnectionString;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connect);
    }
}