// See https://aka.ms/new-console-template for more information
using Ams2SharedComponents;
using Ams2SharedMemoryWatcher.Data;
using Ams2SharedMemoryWatcher.Services;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

string AMS2_PROCESS_NAME = "AMS2AVX";
int PROCESS_WATCHER_INTERVAL_MS = 5000;

Console.WriteLine("Starting AMS2 Shared Memory Watcher...");

ConfigFileReaderService cfrs = new ConfigFileReaderService();
SharedMemoryWatcherConfiguration configuration = cfrs.GetConfiguration();

Console.WriteLine($"API @: {configuration.ApiConnectionString}");
Console.WriteLine($"Simulator ID: {configuration.SimulatorId}");

while (true)
{
    if (Process.GetProcessesByName(AMS2_PROCESS_NAME).Length > 0)
    {
        try
        {
            MemoryMappedFileWatcherService fileWatcher = new MemoryMappedFileWatcherService(configuration);
            await fileWatcher.Start();
        }
        catch (FileNotFoundException)
        {
            // AMS2 Started but Memory Mapped File doesn't exist yet.
            Console.WriteLine($"AMS2 Running, but memory file doesn't exist yet. Retrying in {PROCESS_WATCHER_INTERVAL_MS}ms.");
        }
    }
    Thread.Sleep(PROCESS_WATCHER_INTERVAL_MS);
}