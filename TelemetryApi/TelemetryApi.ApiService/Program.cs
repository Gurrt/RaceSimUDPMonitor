using Ams2SharedComponents;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Diagnostics;
using TelemetryApi.ApiService.Database;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.AddNpgsqlDbContext<RacesimDbContext>("postgresdb");

var app = builder.Build();
int cntr = 0;
List<SharedMemory> allMemories = new List<SharedMemory>();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapPost("/telemetry", async([FromBody]Stream data) =>
{
    SharedMemory rcd = await MessagePackSerializer.DeserializeAsync<SharedMemory>(data);
    allMemories.Add(rcd);
    if (++cntr % 100 == 0)
    {
        cntr = 0;
        Console.WriteLine($"[{DateTime.Now.ToString()}] Current Speed: {rcd.mSpeed} m/s.");
    }
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
