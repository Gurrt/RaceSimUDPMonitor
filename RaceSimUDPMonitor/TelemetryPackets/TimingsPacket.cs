namespace Gurrt.RaceSimUDPMonitor.TelemetryPackets
{
    /// <summary>
    /// Used for relatives during the race only?
    /// </summary>
    public class TimingsPacket: Packet
    {
        private static readonly int MAX_PARTICIPANTS = 32;
        public int sNumParticipants;										// 12 --
	    public uint sParticipantsChangedTimestamp;							// 13 - 16 -- 
	    public float sEventTimeRemaining;									// 17  // time remaining, -1 for invalid time,  -1 - laps remaining in lap based races  --
	    public float sSplitTimeAhead;										// 21 --
	    public float sSplitTimeBehind;										// 25 -- 
	    public float sSplitTime;												// 29 --
	    public ParticipantTimingInfo[] sPartcipants = new ParticipantTimingInfo[MAX_PARTICIPANTS];		// 33 1024
	    public byte sLocalParticipantIndex;		

        public TimingsPacket(BinaryReader br)
        {
            sNumParticipants = (int)br.ReadByte();
            sParticipantsChangedTimestamp = (uint)br.ReadUInt32();
            sEventTimeRemaining = br.ReadSingle();
            sSplitTimeAhead = br.ReadSingle();
            sSplitTimeBehind = br.ReadSingle();
            sSplitTime = br.ReadSingle();
            for (int i = 0; i < MAX_PARTICIPANTS; i++)
            {
                sPartcipants[i] = new ParticipantTimingInfo(br);
            }
            sLocalParticipantIndex = br.ReadByte();
        }
    }
    public class ParticipantTimingInfo
    {
        public Int16[] sWorldPosition = new Int16[3];				// 0 -- 
        public Int16[] sOrientation = new Int16[3];				// 6 -- Quantized heading (-PI .. +PI) , Quantized pitch (-PI / 2 .. +PI / 2),  Quantized bank (-PI .. +PI).
        public UInt16 sCurrentLapDistance;							// 12 --
        public byte sRacePosition;									// 14 -- holds the race position, + top bit shows if the participant is active or not
        public byte sSector;										// 15 -- sector + extra precision bits for x/z position
        public byte sHighestFlag;									// 16 -- (enum 3 bits/enum 2 bits) Flag colour and reason
        public byte sPitModeSchedule;								// 17 -- (enum 3 bits/enum 2 bits) Pit mode and Pit schedule 
        public UInt16 sCarIndex;									// 18 -- top bit shows if participant is (local or remote) human player or not
        public byte sRaceState;									// 20 -- race state flags + invalidated lap indication --
        public byte sCurrentLap;									// 21 -- 
        public float sCurrentTime;                                 // 22 --
        public float sCurrentSectorTime;                           // 26 --
        public byte sMPParticipantIndex;							// 30 --  matching sIndex from sParticipantsData

        public ParticipantTimingInfo(BinaryReader br)
        {
            sWorldPosition[0] = br.ReadInt16();
            sWorldPosition[1] = br.ReadInt16();
            sWorldPosition[2] = br.ReadInt16();
            sOrientation[0] = br.ReadInt16();
            sOrientation[1] = br.ReadInt16();
            sOrientation[2] = br.ReadInt16();
            sCurrentLapDistance = br.ReadUInt16();
            sRacePosition = br.ReadByte();
            sSector = br.ReadByte();
            sHighestFlag = br.ReadByte();
            sPitModeSchedule = br.ReadByte();
            sCarIndex = br.ReadUInt16();
            sRaceState = br.ReadByte();
            sCurrentLap = br.ReadByte();
            sCurrentTime = br.ReadSingle();
            sCurrentSectorTime = br.ReadSingle();
            sMPParticipantIndex = br.ReadByte();
        }
    }
}