using Industriall.API.Data;
using Industriall.API.Extensions;
using Industriall.API.Services;
using Industriall.Application.Interfaces;
using Industriall.Data.Models;
using Industriall.Identity.Configurations;
using Industriall.Identity.Data;
using Industriall.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddApiProblemDetails();
builder.Services.AddAuthorizationPolicies();


builder.Services.Configure<IndustriallDatabaseSettings>(
    builder.Configuration.GetSection("IndustriallDatabaseSettings"));
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<IndustriallContext>();
builder.Services.AddDbContext<IdentityDataContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<EventUserService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();