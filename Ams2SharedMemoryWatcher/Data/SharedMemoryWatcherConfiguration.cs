using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams2SharedMemoryWatcher.Data
{
    internal class SharedMemoryWatcherConfiguration
    {
        public string ApiConnectionString { get; set; } = "http://localhost:5523";

        public string SimulatorId { get; set; } = "ReplaceWithRealSimulatorId";
    }
}
