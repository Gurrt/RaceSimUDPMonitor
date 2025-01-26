using Ams2SharedComponents;
using TelemetryApi.Data.Models;

namespace TelemetryApi.ApiService.Interfaces
{
    public interface ISimulatorSessionTrackingService
    {
        void IngestTelemetry(SharedMemory sharedMemory, string simulatorId);

        Session? GetSession(string simulatorId);
    }
}
