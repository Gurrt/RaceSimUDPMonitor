var builder = DistributedApplication.CreateBuilder(args);


var postgres = builder.AddPostgres("postgres")
    .WithDataVolume("RacesimDataVolume")
    .WithPgAdmin();

var postgresdb = postgres.AddDatabase("postgresdb", "racesimdb");

var apiService = builder.AddProject<Projects.TelemetryApi_ApiService>("apiservice")
    .WithReference(postgresdb);

builder.AddProject<Projects.TelemetryApi_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();