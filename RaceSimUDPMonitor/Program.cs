using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Gurrt.RaceSimUDPMonitor.DataDumpReader;
using Gurrt.RaceSimUDPMonitor.PacketReader;
using Gurrt.RaceSimUDPMonitor.TelemetryPackets;

string dataFolder = "/Users/GerKrijnen";
string currentFolder = "";
int UdpPort = 5606;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CheckDataFolder();
CheckCreateFolderForToday();
//await StartUDPLogger();


PacketReader packetReader = new PacketReader();
string folderToAnalyze = "/Users/GerKrijnen/2024-10-07/datadump/192.168.1.101";
DataDumpReader dataDumpReader = new DataDumpReader(folderToAnalyze);
Dictionary<Type, int> packetCounters = new Dictionary<Type, int>();
foreach (byte[] packet in dataDumpReader.ReadAllPacketsInDump())
{
    Packet parsedPacket = packetReader.ReadPacket(packet);
    if (!packetCounters.ContainsKey(parsedPacket.GetType()))
    {
        packetCounters[parsedPacket.GetType()] = 1;
    }
    else
    {
        packetCounters[parsedPacket.GetType()]++;
    }
}

Console.WriteLine($"Packet stats for session:");
foreach (Type type in packetCounters.Keys)
{
    Console.WriteLine($"\t{type.ToString()}:{packetCounters[type]}");
}


void CheckDataFolder()
{
    if(!Directory.Exists(dataFolder))
    {
        Console.WriteLine($"ERROR: Data Folder expected at: {dataFolder}. But does not exist.");
        throw new Exception("DATA FOLDER MISSING");
    }
    Console.WriteLine($"Data folder found @ {dataFolder}");
}

void CheckCreateFolderForToday()
{
    string today = DateTime.Now.ToString("yyyy-MM-dd");
    currentFolder = $"{dataFolder}/{today}";
    if (Directory.Exists(currentFolder))
    {
        Console.WriteLine($"Folder with current data already exists, not creating.");
    }
    else
    {
        Directory.CreateDirectory(currentFolder);
        Console.WriteLine($"Directory for today created at: {currentFolder}");
    }

    currentFolder += "/datadump";
    if (Directory.Exists(currentFolder))
    {
        Console.WriteLine($"Data dump for current day exists, not creating.");
    }
    else
    {
        Directory.CreateDirectory(currentFolder);
        Console.WriteLine($"Directory for data dump created at: {currentFolder}");
    }
}

Task StartUDPLogger()
{
    return Task.Run(() => {
        UdpClient client = new UdpClient(UdpPort);
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
        Stopwatch sw = null;
        Dictionary<string, bool> createdDirs = new Dictionary<string, bool>();
        try
        {
            Console.WriteLine($"Starting new UDP listener at port {UdpPort}");
            long timeElapsed = 0;
            while(true)
            {
                Byte[] receiveBytes = client.Receive(ref iPEndPoint);
                if (sw == null)
                {
                    sw = new Stopwatch();
                    sw.Start();
                }
                else
                {
                    timeElapsed = sw.ElapsedMilliseconds;
                }

                string ipAsDir = iPEndPoint.Address.ToString();
                if (!createdDirs.ContainsKey(ipAsDir))
                {
                    Directory.CreateDirectory(currentFolder + "/" + ipAsDir);
                }
                string fileName = $"{timeElapsed}.bin";
                File.WriteAllBytes($"{currentFolder}/{ipAsDir}/{fileName}", receiveBytes);
                Console.WriteLine($"Writen {fileName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error receiving UDP packet: " + ex.ToString());
        }
    });
}