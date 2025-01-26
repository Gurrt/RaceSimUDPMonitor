using Ams2SharedComponents;
using Ams2SharedMemoryWatcher.Data;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Ams2SharedMemoryWatcher.Services
{
    internal class MemoryMappedFileWatcherService
    {
        private readonly SharedMemoryWatcherConfiguration configuration;
        private readonly string MEMORY_MAPPED_FILENAME = "$pcars2$";
        public MemoryMappedFileWatcherService(SharedMemoryWatcherConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Start()
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MEMORY_MAPPED_FILENAME))
            {
                using (var acc = mmf.CreateViewStream())
                using (BinaryReader br = new BinaryReader(acc))
                using (HttpClient client = new HttpClient())
                {
                    while (true)
                    {
                        br.BaseStream.Position = 0;
                        SharedMemory sm = new SharedMemory(br); // Current parsing takes about 0.2ms
                        if (sm.mSequenceNumber % 2 == 1)
                        {
                            // Only Even numbers mean that we have a complete write; try again.
                            continue;
                        }
                        using (ByteArrayContent content = new ByteArrayContent(MessagePackSerializer.Serialize(sm)))
                        {
                            try
                            {
                                content.Headers.Add("Simulator-Id", configuration.SimulatorId);
                                HttpResponseMessage hrm = await client.PostAsync($"{configuration.ApiConnectionString}/telemetry", content);
                                await Task.Delay(8);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error communicating with telemetry server: " + ex.Message.ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}
