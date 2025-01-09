namespace TelemetryApi.Web;

public class SimulatorApiClient(HttpClient httpClient)
{
    public async Task<SimulatorDTO[]> GetSimulators(CancellationToken cancellationToken = default)
    {
        List<SimulatorDTO>? simulators = null;

        await foreach (var simulator in httpClient.GetFromJsonAsAsyncEnumerable<SimulatorDTO>("/simulators", cancellationToken))
        {
            if (simulator is not null)
            {
                simulators ??= [];
                simulators.Add(simulator);
            }
        }

        return simulators?.ToArray() ?? [];
    }
}
public record SimulatorDTO(string FriendlyName, long NumSessions, bool Connected)
{
}