using FusionAPI.Applicatif.Core;
using FusionAPI.Applicatif.UseCases;
using FusionAPI.Domain.Repositories.Core;
using FusionAPI.Persistence;
using FusionAPI.Persistence.Repositories;
using FusionAPI.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;

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

ConfigureDbContext<EvaluationManagerContext>(builder.Services, builder.Configuration);

// fusion inject repositories
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

// fusion inject use cases
builder.Services.AddTransient<IAddEvaluationUseCase, AddEvaluationUseCase>();
builder.Services.AddTransient<IGetAllEvaluationsUseCase, GetAllEvaluationsUseCase>();
builder.Services.AddTransient<IGetEvaluationByIdUseCase, GetEvaluationByIdUseCase>();
builder.Services.AddTransient<IDeleteEvaluationByIdUseCase, DeleteEvaluationByIdUseCase>();

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

// Configure the HTTP request pipeline.

app.UseCors("*");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

void MigrateAndSeedDatabase<TContext>(IServiceProvider services) where TContext : DbContext
{
    using var scope = services.CreateScope();
    var context = scope.ServiceProvider.GetService<TContext>()!;
    context.Database.Migrate();

    if (typeof(TContext) == typeof(EvaluationManagerContext))
    {
        Console.WriteLine("Pre seeding database");
        DbSeeder.Initialize(scope.ServiceProvider);
    }
}

// auto migrate and seed database
MigrateAndSeedDatabase<EvaluationManagerContext>(app.Services);

//connection string
//Console.WriteLine(app.Configuration.GetConnectionString("Default"));

app.Run();