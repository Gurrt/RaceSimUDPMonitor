namespace Gurrt.RaceSimUDPMonitor.TelemetryPackets
{
    // TODO: Wrong packet, should be sParticipantsData from line 180
    public class ParticipantsPacket: Packet
    {
        private static readonly int MAX_PARTICIPANTS = 32;
        public ParticipantsStatsInfo[] sParticipants = new ParticipantsStatsInfo[MAX_PARTICIPANTS];

        public ParticipantsPacket(BinaryReader br)
        {
            for (int i = 0; i < MAX_PARTICIPANTS; i++)
            {
                sParticipants[i] = new ParticipantsStatsInfo(br);
            }
        }
    }

    public class ParticipantsStatsInfo
    {
        public float							sFastestLapTime;								// 0
        public float							sLastLapTime;									// 4
        public float							sLastSectorTime;								// 8
        public float							sFastestSector1Time;							// 11
        public float							sFastestSector2Time;							// 16
        public float							sFastestSector3Time;							// 20
        public uint				sParticipantOnlineRep;							// 24 (u16 rank type + u16 strength, 0 in SP races)
        public UInt16					sMPParticipantIndex;	

        public ParticipantsStatsInfo(BinaryReader br)
        {
            sFastestLapTime = br.ReadSingle();
            sLastLapTime = br.ReadSingle();
            sLastSectorTime = br.ReadSingle();
            sFastestSector1Time = br.ReadSingle();
            sFastestSector2Time = br.ReadSingle();
            sFastestSector3Time = br.ReadSingle();
            sParticipantOnlineRep = br.ReadUInt32();
            sMPParticipantIndex = br.ReadUInt16();
        }	
    }
}