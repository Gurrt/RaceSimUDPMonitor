// See https://aka.ms/new-console-template for more information
using Ams2SharedComponents;
using Ams2SharedMemoryWatcher;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
MemoryMappedFileWatcher fileWatcher = new MemoryMappedFileWatcher();
await fileWatcher.Start();