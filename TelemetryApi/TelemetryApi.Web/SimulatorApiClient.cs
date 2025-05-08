namespace TelemetryApi.Web;

public class SimulatorApiClient(HttpClient httpClient, DriverApiClient driverApiClient)
{
    public async Task<Simulator[]> GetSimulators(CancellationToken cancellationToken = default)
    {
        List<Simulator>? simulators = null;

        await foreach (var simulator in httpClient.GetFromJsonAsAsyncEnumerable<SimulatorDTO>("/simulators", cancellationToken))
        {
            if (simulator is not null)
            {
                simulators ??= [];
                simulators.Add(await Simulator.FromDTO(simulator, driverApiClient));
            }
        }

        return simulators?.ToArray() ?? [];
    }
}

public class Simulator()
{
    public string FriendlyName { get; set; } = string.Empty;
    public long NumSessions { get; set; }
    public string DriverName { get; set; } = "None";
    public bool Connected { get; set; }

    public static async Task<Simulator> FromDTO(SimulatorDTO dto, DriverApiClient driverApiClient)
    {
        Simulator sim = new Simulator()
        {
            FriendlyName = dto.FriendlyName,
            NumSessions = dto.NumSessions,
            Connected = dto.Connected,
        };
        if (dto.DriverId != null)
        {
            DriverDTO driverDTO = await driverApiClient.GetDriverAsync(dto.DriverId.Value);
            if (driverDTO.Id > 0 && !string.IsNullOrEmpty(driverDTO.Name))
            {
                sim.DriverName = driverDTO.Name;
            }
        }
        return sim;
    }
}

public record SimulatorDTO(string FriendlyName, long NumSessions, int? DriverId, bool Connected)
{
}