using Gurrt.RaceSimUDPMonitor.TelemetryPackets;

namespace Gurrt.RaceSimUDPMonitor.PacketReader 
{
    class PacketReader
    {
        public PacketReader()
        {
        }

// TODO: Class 8 can have multiple packets.
// Basing on: https://github.com/saildeep/pcars2-udp/blob/master/SMS_UDP_Definitions.hpp#L285
        public Packet ReadPacket(byte[] packet)
        {
            //Console.WriteLine("Packet has: " + packet.Length + " bytes.");
            using (MemoryStream ms = new MemoryStream(packet))
            using (BinaryReader br = new BinaryReader(ms))
            {
                PacketHeader ph = new PacketHeader(br);
                Packet parsedPacket = new UnknownPacket();
                switch ((PacketType) ph.mPacketType)
                {
                    case PacketType.eTimings:
                    {
                        TimingsPacket tp = new TimingsPacket(br);
                        parsedPacket = tp;
                        if (tp.sPartcipants[0].sCurrentLapDistance != 0)
                        {
                            //Console.WriteLine($"Got Timings Packet, lap: {tp.sPartcipants[0].sCurrentLap}, dist: {tp.sPartcipants[0].sCurrentLapDistance}, time: {tp.sPartcipants[0].sCurrentTime}");
                        }
                        break;
                    }
                    case PacketType.eParticipants:
                    {
                        ParticipantsPacket pp = new ParticipantsPacket(br);
                        parsedPacket = pp;
                        ParticipantsStatsInfo psi = pp.sParticipants[0];
                        Console.WriteLine($"Got Particpants packet: last sector: {psi.sLastSectorTime}, last lap: {psi.sLastLapTime}, s1: {psi.sFastestSector1Time}, s2: {psi.sFastestSector2Time}, s3: {psi.sFastestSector3Time}");
                        break;
                    }
                    default: break;
                }
                if (ph.mPartialPacketIndex != 1)
                {
                    Console.WriteLine($"Packet contents:\nnum: {ph.mPacketNumber}\ncat_num: {ph.mCategoryPacketNumber}\ntype: {ph.mPacketType}\n");
                }
                return parsedPacket;
            }
        }
    }
}