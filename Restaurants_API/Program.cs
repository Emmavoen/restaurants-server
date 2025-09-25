using Restaurants.Application;
using Restaurants.Infrastructure;
using Restaurants.Infrastructure.seeders;
using Restaurants_API.Middlewares;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Register the infrastructure services
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.RegisterPersistenceService(configuration);
builder.Services.RegisterApplicationService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((context, configuration) =>

configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

var scope = app.Services.CreateScope();
// Seed the database with initial data
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
