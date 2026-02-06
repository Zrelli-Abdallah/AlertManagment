using alertingSystemBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Get connexionString of data base from appsettings file (Check that sttings file)
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("BackendAPI")
    )
);

//register the alert service
builder.Services.AddScoped<IAlerteServicePostgres, AlerteServicePostgres>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapAlerteEndpoints();
app.Run();


