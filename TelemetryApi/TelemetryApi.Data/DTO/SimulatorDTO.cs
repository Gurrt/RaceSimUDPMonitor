using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelemetryApi.Data.Models;

namespace TelemetryApi.Data.DTO
{
    public record SimulatorDTO(string FriendlyName, long NumSessions, int? DriverId, bool Connected)
    {
    }
}
