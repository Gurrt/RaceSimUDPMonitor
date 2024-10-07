namespace Gurrt.RaceSimUDPMonitor.TelemetryPackets
{
    public class PacketHeader
    {
        public uint mPacketNumber; //0-3 counter reflecting all the packets that have been sent during the game run
        public uint mCategoryPacketNumber;	//4-7 counter of the packet groups belonging to the given category
        public int	mPartialPacketIndex; //8 If the data from this class had to be sent in several packets, the index number
        public int mPartialPacketNumber; //9 If the data from this class had to be sent in several packets, the total number
        public int mPacketType; //10 what is the type of this packet (see EUDPStreamerPacketHanlderType for details)
        public int mPacketVersion; //11 what is the version of protocol for this handler, to be bumped with data structure change

        public PacketHeader(BinaryReader br)
        {
            mPacketNumber = br.ReadUInt32();
            mCategoryPacketNumber = br.ReadUInt32();
            mPartialPacketIndex = (int)br.ReadByte();
            mPartialPacketNumber = (int)br.ReadByte();
            mPacketType = (int)br.ReadByte();
            mPacketVersion = (int)br.ReadByte();
        }
    }
}