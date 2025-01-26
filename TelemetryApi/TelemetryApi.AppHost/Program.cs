var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume("RacesimDataVolume")
    .WithPgAdmin();

var postgresdb = postgres.AddDatabase("postgresdb", "racesimdb");

/*
var signalr = builder.AddProject<Projects.TelemetryApi_SignalRHub>("signalR")
    .WithExternalHttpEndpoints();
*/

var apiService = builder.AddProject<Projects.TelemetryApi_ApiService>("apiservice")
    .WithReference(postgresdb);

builder.AddProject<Projects.TelemetryApi_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.TelemetryApi_DbMigrationService>("telemetryapi-dbmigrationservice")
    .WithReference(postgresdb);

builder.Build().Run();
