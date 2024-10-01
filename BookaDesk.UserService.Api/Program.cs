using BookaDesk.UserService.Api.Endpoints;
using BookaDesk.UserService.Application;
using BookaDesk.UserService.Domain;
using BookaDesk.UserService.Domain.Services;
using BookaDesk.UserService.Infrastructure;

namespace BookaDesk.UserService.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var mongoDbConnectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
        Console.WriteLine(mongoDbConnectionString);

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // BookaDesk.UserService.Application
        builder.Services.ConfigureApplication();

        // BookaDesk.UserService.Domain
        builder.Services.ConfigureDomain();

        // BookaDesk.UserService.Infrastructure
        builder.Services.ConfigureMongoDb(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        // Endpoints
        app.MapUserServiceEndpoints();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = summaries[Random.Shared.Next(summaries.Length)]
                        })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.Run();
    }
}