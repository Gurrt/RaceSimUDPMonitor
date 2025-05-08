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
        policy.WithOrigins("*")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .WithExposedHeaders("Content-Disposition");
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
    await sessionTrackingService.IngestTelemetry(rcd, simulatorId);
});

app.MapGet("/simulators", (RacesimDbContext context) =>
{
    return context.Simulators.Select(sim => new SimulatorDTO(sim.FriendlyName, sim.NumSessions, sim.CurrentDriverId, false)).ToArray();
});

app.MapGet("/drivers", async (RacesimDbContext context) =>
{
    var drivers = await context.Drivers.ToListAsync();
    return drivers.Select(DriverDTO.FromModel);
});

app.MapGet("/drivers/{id}", async (int id, RacesimDbContext context) =>
{
    var driver = await context.Drivers.FindAsync(id);
    if (driver == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(DriverDTO.FromModel(driver));
});

app.MapPost("/drivers", async ([FromBody] DriverDTO driverDto, RacesimDbContext context) =>
{
    var driver = new Driver { Name = driverDto.Name };
    context.Drivers.Add(driver);
    try
    {
        await context.SaveChangesAsync();
        return Results.Created($"/drivers/{driver.Id}", DriverDTO.FromModel(driver));
    }
    catch (DbUpdateException)
    {
        return Results.Conflict("A driver with this name already exists.");
    }
});

app.MapPut("/drivers/{id}", async (int id, [FromBody] DriverDTO driverDto, RacesimDbContext context) =>
{
    var driver = await context.Drivers.FindAsync(id);
    if (driver == null)
    {
        return Results.NotFound();
    }

    driver.Name = driverDto.Name;
    try
    {
        await context.SaveChangesAsync();
        return Results.Ok(DriverDTO.FromModel(driver));
    }
    catch (DbUpdateException)
    {
        return Results.Conflict("A driver with this name already exists.");
    }
});

app.MapDelete("/drivers/{id}", async (int id, RacesimDbContext context) =>
{
    var driver = await context.Drivers.FindAsync(id);
    if (driver == null)
    {
        return Results.NotFound();
    }

    context.Drivers.Remove(driver);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPost("/simulators/{simulatorId}/driver/{driverId}", async (string simulatorId, int driverId, RacesimDbContext context) =>
{
    var simulator = await context.Simulators.FindAsync(simulatorId);
    if (simulator == null)
    {
        return Results.NotFound("Simulator not found");
    }

    var driver = await context.Drivers.FindAsync(driverId);
    if (driver == null)
    {
        return Results.NotFound("Driver not found");
    }

    simulator.CurrentDriverId = driverId;
    await context.SaveChangesAsync();
    return Results.Ok(new SimulatorDTO(simulator.FriendlyName, simulator.NumSessions, simulator.CurrentDriverId, false));
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
