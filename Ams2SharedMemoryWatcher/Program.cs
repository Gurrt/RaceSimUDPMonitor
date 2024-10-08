// See https://aka.ms/new-console-template for more information
using Ams2SharedMemoryWatcher;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

const string MEMORY_MAPPED_FILENAME = "$pcars2$";
try
{
    using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MEMORY_MAPPED_FILENAME))
    {
        using (var acc = mmf.CreateViewStream())
        using (BinaryReader br = new BinaryReader(acc))
        {
            SharedMemory sm = new SharedMemory(br);
            Console.WriteLine("Got file, version: " + sm.mVersion);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"ERR opening memory mapped file: {ex.ToString()}");
}