using Ams2SharedComponents;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Ams2SharedMemoryWatcher
{
    internal class MemoryMappedFileWatcher
    {
        private readonly string MEMORY_MAPPED_FILENAME = "$pcars2$";
        public MemoryMappedFileWatcher()
        {
        
        }

        public async Task Start()
        {
            const string APP_HOST = "http://localhost:5523";
            try
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
                                    HttpResponseMessage hrm = await client.PostAsync($"{APP_HOST}/telemetry", content);
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
            catch (Exception ex)
            {
                Console.WriteLine($"ERR opening memory mapped file: {ex.ToString()}");
            }
        }
    }
}
