using TelemetryApi.Data.Contexts;
using TelemetryApi.DbMigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddNpgsqlDbContext<RacesimDbContext>("postgresdb");

var host = builder.Build();
host.Run();
