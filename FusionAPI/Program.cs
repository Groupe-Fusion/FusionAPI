using FusionAPI.Applicatif.Core;
using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Models;
using FusionAPI.Domain.Repositories.Core;
using FusionAPI.Persistence;
using FusionAPI.Persistence.Repositories;
using FusionAPI.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

void ConfigureDbContext<TContext>(IServiceCollection services, IConfiguration configuration) where TContext : DbContext
{
    var sqlConnectionString = configuration.GetConnectionString("Default");
    if (sqlConnectionString is null)
        throw new ArgumentNullException("No connection string found");

    services.AddDbContext<TContext>(options =>
    {
        options.UseSqlServer(
            sqlConnectionString,
            b => b.MigrationsAssembly("FusionAPI.Persistence"));
    });
}

ConfigureDbContext<UserManagerContext>(builder.Services, builder.Configuration);

// ajout mongoDB service
builder.Services.Configure<LocalisationDatabaseSettings>(
    builder.Configuration.GetSection("LocalisationDatabase"));

builder.Services.AddSingleton<LocalisationRepository>();

// fusion inject repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ILocalisationRepository, LocalisationRepository>();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "*",
        policy =>
        {
            policy.WithOrigins("*") // ou ton frontend (React, Angular, etc.)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("*");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
