using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "APIIndustriall",
            Description = "API de usuarios e eventos, desafio tecnico dado pela Instriall", 
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Rogério Medeiros",
                Url = new Uri("https://github.com/RogerioMSantos"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        });
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "APIIndustriall v1");
    options.RoutePrefix = string.Empty;
});

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();