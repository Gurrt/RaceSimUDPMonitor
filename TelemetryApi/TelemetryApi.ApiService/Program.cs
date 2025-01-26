using Ams2SharedComponents;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TelemetryApi.ApiService.Hubs;
using TelemetryApi.ApiService.Interfaces;
using TelemetryApi.ApiService.Services;
using TelemetryApi.Data.Contexts;
using TelemetryApi.Data.DTO;
using TelemetryApi.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.AddNpgsqlDbContext<RacesimDbContext>("postgresdb");

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*");
        policy.WithHeaders(["Origin", "X-Requested-With", "Content-Type", "Accept", "X-Signalr-User-Agent"]);
    });
});

builder.Services.AddScoped<ISimulatorSessionTrackingService, SimulatorSessionTrackingService>();

var app = builder.Build();
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

app.MapPost("/telemetry", async(
    [FromBody]Stream data,
    [FromHeader(Name="Simulator-Id")] string simulatorId,
    IHubContext<RealtimeTelemetryHub> hub,
    ISimulatorSessionTrackingService sessionTrackingService) =>
{
    SharedMemory rcd = await MessagePackSerializer.DeserializeAsync<SharedMemory>(data);
    sessionTrackingService.IngestTelemetry(rcd, simulatorId);
});

app.MapGet("/simulators", (RacesimDbContext context) =>
{
    return context.Simulators.Select(sim => new SimulatorDTO(sim.FriendlyName, sim.NumSessions, false)).ToArray();
});

app.MapHub<RealtimeTelemetryHub>("/realtimeTelemetryHub");

app.MapDefaultEndpoints();

app.UseCors();

app.Run();

record SimulatorRecord(string Name, int numSessions)
{

}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
