using TelemetryApi.SignalRHub.Hubs;

string corsPolicyName = "signalRCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.WithOrigins("*");
        policy.WithHeaders(["Origin", "X-Requested-With", "Content-Type", "Accept", "X-Signalr-User-Agent"]);
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapHub<RealtimeTelemetryHub>("/realtimeTelemetryHub");

app.UseCors(corsPolicyName);

app.Run();
