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

ConfigureDbContext<UserManagerContext>(builder.Services, builder.Configuration);

// fusion inject repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// fusion inject use cases
builder.Services.AddTransient<IAddReservationUseCase, AddReservationUseCase>();
builder.Services.AddTransient<IGetAllReservationsUseCase, GetAllReservationsUseCase>();
builder.Services.AddTransient<IGetReservationByIdUseCase, GetReservationByIdUseCase>();
builder.Services.AddTransient<IDeleteReservationUseCase, DeleteReservationUseCase>();

// Add HttpClient service
builder.Services.AddHttpClient("ReservationService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ExternalServices:ReservationService:Url"]);
});

// Add services to the container.
builder.Services.AddControllers();

// PROVOQUE DES JSONS BIZARRE ATTENTION
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("*");

// Configure the HTTP request pipeline.
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

    if (typeof(TContext) == typeof(UserManagerContext))
    {
        Console.WriteLine("Pre seeding database");
        DbSeeder.Initialize(scope.ServiceProvider);
    }
}

// auto migrate and seed database
MigrateAndSeedDatabase<UserManagerContext>(app.Services);

//connection string
//Console.WriteLine(app.Configuration.GetConnectionString("Default"));

app.Run();
