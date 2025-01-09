using TelemetryApi.Web;
using TelemetryApi.Web.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TelemetryApi.Web.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TelemetryApiWebContext>(options => options.UseNpgsql("postgresdb"));

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

builder.Services.AddHttpClient<WeatherApiClient>(ConfigureHttpClient);
builder.Services.AddHttpClient<SimulatorApiClient>(ConfigureHttpClient);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();

static void ConfigureHttpClient(HttpClient client)
{
    client.BaseAddress = new("https+http://apiservice");
}