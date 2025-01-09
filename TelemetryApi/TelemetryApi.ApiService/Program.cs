using Ams2SharedComponents;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using TelemetryApi.Data.Contexts;
using TelemetryApi.Data.DTO;
using TelemetryApi.Data.Models;

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

float lastKnownLaptime = float.MaxValue;

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
    if (rcd.mLastLapTime != lastKnownLaptime)
    {
        lastKnownLaptime = rcd.mLastLapTime;
        int minutes = (int) Math.Floor(lastKnownLaptime / 60);
        int seconds = (int)Math.Floor(lastKnownLaptime % 60);
        int miliseconds = (int)(1000 * (lastKnownLaptime - Math.Floor(lastKnownLaptime)));

        string secondsString = seconds < 10 ? "0" + seconds : seconds.ToString();
        string milisecondsString = miliseconds < 10 ? "00" + miliseconds :
            miliseconds < 100 ? "0" + miliseconds :
            miliseconds.ToString();

        string laptimeString = $"{minutes}:{secondsString}.{milisecondsString}";

        Console.WriteLine($"New lap from driver: ${laptimeString}");
    }
    allMemories.Add(rcd);
});

app.MapGet("/simulators", (RacesimDbContext context) =>
{
    return context.Simulators.Select(sim => new SimulatorDTO(sim.FriendlyName, sim.NumSessions, false)).ToArray();
});

app.MapDefaultEndpoints();

app.Run();

record SimulatorRecord(string Name, int numSessions)
{

}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
