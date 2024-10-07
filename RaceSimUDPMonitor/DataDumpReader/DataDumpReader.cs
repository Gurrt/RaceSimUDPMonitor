using System.IO;
namespace Gurrt.RaceSimUDPMonitor.DataDumpReader
{
    public class DataDumpReader
    {
        private string DumpDir;
        public DataDumpReader(string dir)
        {
            this.DumpDir = dir;
            ValidateDataDumpDirectory();
        }

        private void ValidateDataDumpDirectory()
        {
            if (!Directory.Exists(DumpDir))
            {
                throw new DirectoryDoesNotExistException($"Directory {DumpDir} is empty.");
            }

            if (Directory.GetFiles(DumpDir).Length == 0)
            {
                throw new DirectoryEmptyException($"Directory {DumpDir} is empty.");
            }
        }

        public IEnumerable<byte[]> ReadAllPacketsInDump()
        {
            List<string> packetPaths = Directory.GetFiles(DumpDir).Where(f => f.EndsWith(".bin")).Order().ToList();
            Console.WriteLine($"Got {packetPaths.Count} packets to read.");
            foreach (string path in packetPaths)
            {
                //Console.WriteLine($"reading: {path}.");
                byte[] fileContents = File.ReadAllBytes(path);
                yield return fileContents;
            }
        }
    }
}