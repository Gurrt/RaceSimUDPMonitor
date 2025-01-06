using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams2SharedComponents
{

    public static class SharedMemoryConsts
    {
        public static readonly int SHARED_MEMORY_VERSION = 14;
        public static readonly int STRING_LENGTH_MAX = 64;
        public static readonly int STORED_PARTICIPANTS_MAX = 64;
        public static readonly int TYRE_COMPOUND_NAME_LENGTH_MAX = 40;
    }

    public enum Tyres
    {
        TYRE_FRONT_LEFT = 0,
        TYRE_FRONT_RIGHT,
        TYRE_REAR_LEFT,
        TYRE_REAR_RIGHT,
        //--------------
        TYRE_MAX
    }

    public enum Vector
    {
        VEC_X = 0,
        VEC_Y,
        VEC_Z,
        //-------------
        VEC_MAX
    };

    public enum GameState
    {
        GAME_EXITED = 0,
        GAME_FRONT_END,
        GAME_INGAME_PLAYING,
        GAME_INGAME_PAUSED,
        GAME_INGAME_INMENU_TIME_TICKING,
        GAME_INGAME_RESTARTING,
        GAME_INGAME_REPLAY,
        GAME_FRONT_END_REPLAY,
        //-------------
        GAME_MAX
    }

    public enum SessionState
    {
        SESSION_INVALID = 0,
        SESSION_PRACTICE,
        SESSION_TEST,
        SESSION_QUALIFY,
        SESSION_FORMATION_LAP,
        SESSION_RACE,
        SESSION_TIME_ATTACK,
        //-------------
        SESSION_MAX
    }

    public enum RaceState
    {
        RACESTATE_INVALID,
        RACESTATE_NOT_STARTED,
        RACESTATE_RACING,
        RACESTATE_FINISHED,
        RACESTATE_DISQUALIFIED,
        RACESTATE_RETIRED,
        RACESTATE_DNF,
        //-------------
        RACESTATE_MAX
    }

    public enum FlagColours
    {
        FLAG_COLOUR_NONE = 0,             // Not used for actual flags, only for some query functions
        FLAG_COLOUR_GREEN,                // End of danger zone, or race started
        FLAG_COLOUR_BLUE,                 // Faster car wants to overtake the participant
        FLAG_COLOUR_WHITE_SLOW_CAR,       // Slow car in area
        FLAG_COLOUR_WHITE_FINAL_LAP,      // Final Lap
        FLAG_COLOUR_RED,                  // Huge collisions where one or more cars become wrecked and block the track
        FLAG_COLOUR_YELLOW,               // Danger on the racing surface itself
        FLAG_COLOUR_DOUBLE_YELLOW,        // Danger that wholly or partly blocks the racing surface
        FLAG_COLOUR_BLACK_AND_WHITE,      // Unsportsmanlike conduct
        FLAG_COLOUR_BLACK_ORANGE_CIRCLE,  // Mechanical Failure
        FLAG_COLOUR_BLACK,                // Participant disqualified
        FLAG_COLOUR_CHEQUERED,            // Chequered flag
                                          //-------------
        FLAG_COLOUR_MAX
    }

    public enum FlagReason
    {
        FLAG_REASON_NONE = 0,
        FLAG_REASON_SOLO_CRASH,
        FLAG_REASON_VEHICLE_CRASH,
        FLAG_REASON_VEHICLE_OBSTRUCTION,
        //-------------
        FLAG_REASON_MAX
    }

    public enum PitMode
    {
        PIT_MODE_NONE = 0,
        PIT_MODE_DRIVING_INTO_PITS,
        PIT_MODE_IN_PIT,
        PIT_MODE_DRIVING_OUT_OF_PITS,
        PIT_MODE_IN_GARAGE,
        PIT_MODE_DRIVING_OUT_OF_GARAGE,
        //-------------
        PIT_MODE_MAX
    }

    public enum PitSchedule
    {
        PIT_SCHEDULE_NONE = 0,            // Nothing scheduled
        PIT_SCHEDULE_PLAYER_REQUESTED,    // Used for standard pit sequence - requested by player
        PIT_SCHEDULE_ENGINEER_REQUESTED,  // Used for standard pit sequence - requested by engineer
        PIT_SCHEDULE_DAMAGE_REQUESTED,    // Used for standard pit sequence - requested by engineer for damage
        PIT_SCHEDULE_MANDATORY,           // Used for standard pit sequence - requested by engineer from career enforced lap number
        PIT_SCHEDULE_DRIVE_THROUGH,       // Used for drive-through penalty
        PIT_SCHEDULE_STOP_GO,             // Used for stop-go penalty
        PIT_SCHEDULE_PITSPOT_OCCUPIED,    // Used for drive-through when pitspot is occupied
                                          //-------------
        PIT_SCHEDULE_MAX
    }

    public enum CarFlags
    {
        CAR_HEADLIGHT = (1 << 0),
        CAR_ENGINE_ACTIVE = (1 << 1),
        CAR_ENGINE_WARNING = (1 << 2),
        CAR_SPEED_LIMITER = (1 << 3),
        CAR_ABS = (1 << 4),
        CAR_HANDBRAKE = (1 << 5),
        CAR_TCS = (1 << 6),
        CAR_SCS = (1 << 7),
    }

    public enum TyreFlags
    {
        TYRE_ATTACHED = (1 << 0),
        TYRE_INFLATED = (1 << 1),
        TYRE_IS_ON_GROUND = (1 << 2),
    }

    public enum TerrainMaterials
    {
        TERRAIN_ROAD = 0,
        TERRAIN_LOW_GRIP_ROAD,
        TERRAIN_BUMPY_ROAD1,
        TERRAIN_BUMPY_ROAD2,
        TERRAIN_BUMPY_ROAD3,
        TERRAIN_MARBLES,
        TERRAIN_GRASSY_BERMS,
        TERRAIN_GRASS,
        TERRAIN_GRAVEL,
        TERRAIN_BUMPY_GRAVEL,
        TERRAIN_RUMBLE_STRIPS,
        TERRAIN_DRAINS,
        TERRAIN_TYREWALLS,
        TERRAIN_CEMENTWALLS,
        TERRAIN_GUARDRAILS,
        TERRAIN_SAND,
        TERRAIN_BUMPY_SAND,
        TERRAIN_DIRT,
        TERRAIN_BUMPY_DIRT,
        TERRAIN_DIRT_ROAD,
        TERRAIN_BUMPY_DIRT_ROAD,
        TERRAIN_PAVEMENT,
        TERRAIN_DIRT_BANK,
        TERRAIN_WOOD,
        TERRAIN_DRY_VERGE,
        TERRAIN_EXIT_RUMBLE_STRIPS,
        TERRAIN_GRASSCRETE,
        TERRAIN_LONG_GRASS,
        TERRAIN_SLOPE_GRASS,
        TERRAIN_COBBLES,
        TERRAIN_SAND_ROAD,
        TERRAIN_BAKED_CLAY,
        TERRAIN_ASTROTURF,
        TERRAIN_SNOWHALF,
        TERRAIN_SNOWFULL,
        TERRAIN_DAMAGED_ROAD1,
        TERRAIN_TRAIN_TRACK_ROAD,
        TERRAIN_BUMPYCOBBLES,
        TERRAIN_ARIES_ONLY,
        TERRAIN_ORION_ONLY,
        TERRAIN_B1RUMBLES,
        TERRAIN_B2RUMBLES,
        TERRAIN_ROUGH_SAND_MEDIUM,
        TERRAIN_ROUGH_SAND_HEAVY,
        TERRAIN_SNOWWALLS,
        TERRAIN_ICE_ROAD,
        TERRAIN_RUNOFF_ROAD,
        TERRAIN_ILLEGAL_STRIP,
        TERRAIN_PAINT_CONCRETE,
        TERRAIN_PAINT_CONCRETE_ILLEGAL,
        TERRAIN_RALLY_TARMAC,
        //-------------
        TERRAIN_MAX
    }
    
    public enum CrashDamage
    {
        CRASH_DAMAGE_NONE = 0,
        CRASH_DAMAGE_OFFTRACK,
        CRASH_DAMAGE_LARGE_PROP,
        CRASH_DAMAGE_SPINNING,
        CRASH_DAMAGE_ROLLING,
        //-------------
        CRASH_MAX
    }

    [MessagePackObject]
    public struct ParticipantInfo
    {
        [MessagePack.Key(0)]
        public bool mIsActive;
        [MessagePack.Key(1)]
        public char[] mName = new char[SharedMemoryConsts.STRING_LENGTH_MAX];                   // [ string ]
        [MessagePack.Key(2)]
        public float[] mWorldPosition = new float[(int) Vector.VEC_MAX];                   // [ UNITS = World Space  X  Y  Z ]
        [MessagePack.Key(3)]
        public float mCurrentLapDistance;                       // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]
        [MessagePack.Key(4)]
        public UInt32 mRacePosition;                      // [ RANGE = 1->... ]   [ UNSET = 0 ]
        [MessagePack.Key(5)]
        public UInt32 mLapsCompleted;                     // [ RANGE = 0->... ]   [ UNSET = 0 ]
        [MessagePack.Key(6)]
        public UInt32 mCurrentLap;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
        [MessagePack.Key(7)]
        public int mCurrentSector;                              // [ RANGE = 0->... ]   [ UNSET = -1 ]

        [SerializationConstructor]
        public ParticipantInfo()
        {

        }
        public ParticipantInfo(BinaryReader br)
        {
            int bytesInStruct = 1 + SharedMemoryConsts.STRING_LENGTH_MAX + 4 * 3 + 4 + 4 + 4 + 4 + 4 + 150;
            //byte[] bytesForParticipant = br.ReadBytes(bytesInStruct);
           
            mIsActive = br.ReadBoolean();
            mName = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            br.ReadBytes(3);
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mWorldPosition[i] = br.ReadSingle();
            }
            mCurrentLapDistance = br.ReadSingle();
            mRacePosition = br.ReadUInt32();
            mLapsCompleted = br.ReadUInt32();
            mCurrentLap = br.ReadUInt32();
            mCurrentSector = br.ReadInt32();
        }
    }

    public enum DrsState
    {
        DRS_INSTALLED = (1 << 0),  // Vehicle has DRS capability
        DRS_ZONE_RULES = (1 << 1),  // 1 if DRS uses F1 style rules
        DRS_AVAILABLE_NEXT = (1 << 2),  // detection zone was triggered (only applies to f1 style rules)
        DRS_AVAILABLE_NOW = (1 << 3),  // detection zone was triggered and we are now in the zone (only applies to f1 style rules)
        DRS_ACTIVE = (1 << 4),  // Wing is in activated state
    };

    // (Type#15) ErsDeploymentMode (to be used with 'mErsDeploymentMode')
    public enum ErsDeploymentMode
    {
        ERS_DEPLOYMENT_MODE_NONE = 0, // The vehicle does not support deployment modes
        ERS_DEPLOYMENT_MODE_OFF, // Regen only, no deployment
        ERS_DEPLOYMENT_MODE_BUILD, // Heavy emphasis towards regen
        ERS_DEPLOYMENT_MODE_BALANCED, // Deployment map automatically adjusted to try and maintain target SoC
        ERS_DEPLOYMENT_MODE_ATTACK,  // More aggressive deployment, no target SoC
        ERS_DEPLOYMENT_MODE_QUAL, // Maximum deployment, no target Soc
    };

    // (Type#16) YellowFlagState represents current FCY state (to be used with 'mYellowFlagState')
    public enum YellowFlagState
    {
        YFS_INVALID = -1,
        YFS_NONE,           // No yellow flag pending on track
        YFS_PENDING,        // Flag has been thrown, but not yet taken by leader
        YFS_PITS_CLOSED,    // Flag taken by leader, pits not yet open
        YFS_PIT_LEAD_LAP,   // Those on the lead lap may pit
        YFS_PITS_OPEN,      // Everyone may pit
        YFS_PITS_OPEN2,     // Everyone may pit
        YFS_LAST_LAP,       // On the last caution lap
        YFS_RESUME,         // About to restart (pace car will duck out)
        YFS_RACE_HALT,      // Safety car will lead field into pits
                            //-------------
        YFS_MAXIMUM,
    };

    // (Type#17) LaunchStage current launch control state
    public enum LaunchStage
    {
        LAUNCH_INVALID = -1,    // Launch control unavailable
        LAUNCH_OFF = 0,         // Launch control inactive
        LAUNCH_REV,             // Launch control revving to optimum engine speed
        LAUNCH_ON,              // Launch control actively accelerating vehicle
    };

    [MessagePackObject]
    public partial struct SharedMemory
    {
        // Version Number
        [MessagePack.Key(0)]
        public UInt32 mVersion;                           // [ RANGE = 0->... ]
        [MessagePack.Key(1)]
        public UInt32 mBuildVersionNumber;                // [ RANGE = 0->... ]   [ UNSET = 0 ]

        // Game States
        [MessagePack.Key(2)]
        public GameState mGameState;                         // [ enum (Type#1) Game state ]
        [MessagePack.Key(3)]
        public SessionState mSessionState;                      // [ enum (Type#2) Session state ]
        [MessagePack.Key(4)]
        public RaceState mRaceState;                         // [ enum (Type#3) Race State ]

        // Participant Info
        [MessagePack.Key(5)]
        public int mViewedParticipantIndex;                                  // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        [MessagePack.Key(6)]
        public int mNumParticipants;                                         // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        [MessagePack.Key(7)]
        public ParticipantInfo[] mParticipantInfo = new ParticipantInfo[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];    // [ struct (Type#13) ParticipantInfo struct ]

        // Unfiltered Input
        [MessagePack.Key(8)]
        public float mUnfilteredThrottle;                        // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(9)]
        public float mUnfilteredBrake;                           // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(10)]
        public float mUnfilteredSteering;                        // [ RANGE = -1.0f->1.0f ]
        [MessagePack.Key(11)]
        public float mUnfilteredClutch;                          // [ RANGE = 0.0f->1.0f ]

        // Vehicle information
        [MessagePack.Key(12)]
        char[] mCarName = new char[SharedMemoryConsts.STRING_LENGTH_MAX];                 // [ string ]
        [MessagePack.Key(13)]
        char[] mCarClassName= new char[SharedMemoryConsts.STRING_LENGTH_MAX];            // [ string ]

        // Event information
        [MessagePack.Key(14)]
        public UInt32 mLapsInEvent;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
        [MessagePack.Key(15)]
        public char[] mTrackLocation= new char[SharedMemoryConsts.STRING_LENGTH_MAX];           // [ string ] - untranslated shortened English name
        [MessagePack.Key(16)]
        public char[] mTrackVariation= new char[SharedMemoryConsts.STRING_LENGTH_MAX];          // [ string ]- untranslated shortened English variation description
        [MessagePack.Key(17)]
        public float mTrackLength;                               // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]

        // Timings
        [MessagePack.Key(18)]
        public int mNumSectors;                                  // [ RANGE = 0->... ]   [ UNSET = -1 ]
        [MessagePack.Key(19)]
        public bool mLapInvalidated;                             // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        [MessagePack.Key(20)]
        public float mBestLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(21)]
        public float mLastLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(22)]
        public float mCurrentTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(23)]
        public float mSplitTimeAhead;                            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(24)]
        public float mSplitTimeBehind;                           // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(25)]
        public float mSplitTime;                                 // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(26)]
        public float mEventTimeRemaining;                        // [ UNITS = milli-seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(27)]
        public float mPersonalFastestLapTime;                    // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(28)]
        public float mWorldFastestLapTime;                       // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(29)]
        public float mCurrentSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(30)]
        public float mCurrentSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(31)]
        public float mCurrentSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(32)]
        public float mFastestSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(33)]
        public float mFastestSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(34)]
        public float mFastestSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(35)]
        public float mPersonalFastestSector1Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(36)]
        public float mPersonalFastestSector2Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(37)]
        public float mPersonalFastestSector3Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(38)]
        public float mWorldFastestSector1Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(39)]
        public float mWorldFastestSector2Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(40)]
        public float mWorldFastestSector3Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]

        // Flags
        [MessagePack.Key(41)]
        public FlagColours mHighestFlagColour;                 // [ enum (Type#5) Flag Colour ]
        [MessagePack.Key(42)]
        public FlagReason mHighestFlagReason;                 // [ enum (Type#6) Flag Reason ]

        // Pit Info
        [MessagePack.Key(43)]
        public PitMode mPitMode;                           // [ enum (Type#7) Pit Mode ]
        [MessagePack.Key(44)]
        public PitSchedule mPitSchedule;                       // [ enum (Type#8) Pit Stop Schedule ]

        // Car State
        [MessagePack.Key(45)]
        public CarFlags mCarFlags;                          // [ enum (Type#9) Car Flags ]
        [MessagePack.Key(46)]
        public float mOilTempCelsius;                           // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        [MessagePack.Key(47)]
        public float mOilPressureKPa;                           // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(48)]
        public float mWaterTempCelsius;                         // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        [MessagePack.Key(49)]
        public float mWaterPressureKPa;                         // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(50)]
        public float mFuelPressureKPa;                          // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(51)]
        public float mFuelLevel;                                // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(52)]
        public float mFuelCapacity;                             // [ UNITS = Liters ]   [ RANGE = 0.0f->1.0f ]   [ UNSET = 0.0f ]
        [MessagePack.Key(53)]
        public float mSpeed;                                    // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
        [MessagePack.Key(54)]
        public float mRpm;                                      // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(55)]
        public float mMaxRPM;                                   // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        [MessagePack.Key(56)]
        public float mBrake;                                    // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(57)]
        public float mThrottle;                                 // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(58)]
        public float mClutch;                                   // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(59)]
        public float mSteering;                                 // [ RANGE = -1.0f->1.0f ]
        [MessagePack.Key(60)]
        public int mGear;                                       // [ RANGE = -1 (Reverse)  0 (Neutral)  1 (Gear 1)  2 (Gear 2)  etc... ]   [ UNSET = 0 (Neutral) ]
        [MessagePack.Key(61)]
        public int mNumGears;                                   // [ RANGE = 0->... ]   [ UNSET = -1 ]
        [MessagePack.Key(62)]
        public float mOdometerKM;                               // [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(63)]
        public bool mAntiLockActive;                            // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        [MessagePack.Key(64)]
        public int mLastOpponentCollisionIndex;                 // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        [MessagePack.Key(65)]
        public float mLastOpponentCollisionMagnitude;           // [ RANGE = 0.0f->... ]
        [MessagePack.Key(66)]
        public bool mBoostActive;                               // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        [MessagePack.Key(67)]
        public float mBoostAmount;                              // [ RANGE = 0.0f->100.0f ] 

        // Motion & Device Related
        [MessagePack.Key(68)]
        public float[] mOrientation = new float[(int)Vector.VEC_MAX];                     // [ UNITS = Euler Angles ]
        [MessagePack.Key(69)]
        public float[] mLocalVelocity = new float[(int)Vector.VEC_MAX];                  // [ UNITS = Metres per-second ]
        [MessagePack.Key(70)]
        public float[] mWorldVelocity = new float[(int)Vector.VEC_MAX];                  // [ UNITS = Metres per-second ]
        [MessagePack.Key(71)]
        public float[] mAngularVelocity = new float[(int)Vector.VEC_MAX];                 // [ UNITS = Radians per-second ]
        [MessagePack.Key(72)]
        public float[] mLocalAcceleration = new float[(int)Vector.VEC_MAX];               // [ UNITS = Metres per-second ]
        [MessagePack.Key(73)]
        public float[] mWorldAcceleration = new float[(int)Vector.VEC_MAX];                // [ UNITS = Metres per-second ]
        [MessagePack.Key(74)]
        public float[] mExtentsCentre = new float[(int)Vector.VEC_MAX];                    // [ UNITS = Local Space  X  Y  Z ]

        // Wheels / Tyres
        [MessagePack.Key(75)]
        public TyreFlags[] mTyreFlags = new TyreFlags[(int)Tyres.TYRE_MAX];               // [ enum (Type#10) Tyre Flags ]
        [MessagePack.Key(76)]
        public TerrainMaterials[] mTerrain = new TerrainMaterials[(int)Tyres.TYRE_MAX];                 // [ enum (Type#11) Terrain Materials ]
        [MessagePack.Key(77)]
        public float[] mTyreY = new float[(int)Tyres.TYRE_MAX];                          // [ UNITS = Local Space  Y ]
        [MessagePack.Key(78)]
        public float[] mTyreRPS = new float[(int)Tyres.TYRE_MAX];                        // [ UNITS = Revolutions per second ]
        [MessagePack.Key(79)]
        public float[] mTyreSlipSpeed = new float[(int)Tyres.TYRE_MAX];                  // OBSOLETE, kept for backward compatibility only
        [MessagePack.Key(80)]
        public float[] mTyreTemp = new float[(int)Tyres.TYRE_MAX];                       // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        [MessagePack.Key(81)]
        public float[] mTyreGrip = new float[(int)Tyres.TYRE_MAX];                       // OBSOLETE, kept for backward compatibility only
        [MessagePack.Key(82)]
        public float[] mTyreHeightAboveGround = new float[(int)Tyres.TYRE_MAX];          // [ UNITS = Local Space  Y ]
        [MessagePack.Key(83)]
        public float[] mTyreLateralStiffness = new float[(int)Tyres.TYRE_MAX];           // OBSOLETE, kept for backward compatibility only
        [MessagePack.Key(84)]
        public float[] mTyreWear = new float[(int)Tyres.TYRE_MAX];                       // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(85)]
        public float[] mBrakeDamage = new float[(int)Tyres.TYRE_MAX];                    // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(86)]
        public float[] mSuspensionDamage = new float[(int)Tyres.TYRE_MAX];               // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(87)]
        public float[] mBrakeTempCelsius = new float[(int)Tyres.TYRE_MAX];               // [ UNITS = Celsius ]
        [MessagePack.Key(88)]
        public float[] mTyreTreadTemp = new float[(int)Tyres.TYRE_MAX];                  // [ UNITS = Kelvin ]
        [MessagePack.Key(89)]
        public float[] mTyreLayerTemp = new float[(int)Tyres.TYRE_MAX];                  // [ UNITS = Kelvin ]
        [MessagePack.Key(90)]
        public float[] mTyreCarcassTemp = new float[(int)Tyres.TYRE_MAX];                // [ UNITS = Kelvin ]
        [MessagePack.Key(91)]
        public float[] mTyreRimTemp = new float[(int)Tyres.TYRE_MAX];                    // [ UNITS = Kelvin ]
        [MessagePack.Key(92)]
        public float[] mTyreInternalAirTemp = new float[(int)Tyres.TYRE_MAX];            // [ UNITS = Kelvin ]

        // Car Damage
        [MessagePack.Key(93)]
        public CrashDamage mCrashState;                        // [ enum (Type#12) Crash Damage State ]
        [MessagePack.Key(94)]
        public float mAeroDamage;                               // [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(95)]
        public float mEngineDamage;                             // [ RANGE = 0.0f->1.0f ]

        // Weather
        [MessagePack.Key(96)]
        public float mAmbientTemperature;                       // [ UNITS = Celsius ]   [ UNSET = 25.0f ]
        [MessagePack.Key(97)]
        public float mTrackTemperature;                         // [ UNITS = Celsius ]   [ UNSET = 30.0f ]
        [MessagePack.Key(98)]
        public float mRainDensity;                              // [ UNITS = How much rain will fall ]   [ RANGE = 0.0f->1.0f ]
        [MessagePack.Key(99)]
        public float mWindSpeed;                                // [ RANGE = 0.0f->100.0f ]   [ UNSET = 2.0f ]
        [MessagePack.Key(100)]
        public float mWindDirectionX;                           // [ UNITS = Normalised Vector X ]
        [MessagePack.Key(101)]
        public float mWindDirectionY;                           // [ UNITS = Normalised Vector Y ]
        [MessagePack.Key(102)]
        public float mCloudBrightness;                          // [ RANGE = 0.0f->... ]

        //PCars2 additions start, version 8
        // Sequence Number to help slightly with data integrity reads
        [MessagePack.Key(103)]
        public volatile UInt32 mSequenceNumber;          // 0 at the start, incremented at start and end of writing, so odd when Shared Memory is being filled, even when the memory is not being touched

        //Additional car variables
        [MessagePack.Key(104)]
        public float[] mWheelLocalPositionY= new float[(int)Tyres.TYRE_MAX];           // [ UNITS = Local Space  Y ]
        [MessagePack.Key(105)]
        public float[] mSuspensionTravel= new float[(int)Tyres.TYRE_MAX];              // [ UNITS = meters ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        [MessagePack.Key(106)]
        public float[] mSuspensionVelocity= new float[(int)Tyres.TYRE_MAX];            // [ UNITS = Rate of change of pushrod deflection ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        [MessagePack.Key(107)]
        public float[] mAirPressure= new float[(int)Tyres.TYRE_MAX];                   // [ UNITS = PSI ]  [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        [MessagePack.Key(108)]
        public float mEngineSpeed;                             // [ UNITS = Rad/s ] [UNSET = 0.f ]
        [MessagePack.Key(109)]
        public float mEngineTorque;                            // [ UNITS = Newton Meters] [UNSET = 0.f ] [ RANGE = 0.0f->... ]
        [MessagePack.Key(110)]
        public float[] mWings = new float[2];                                // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]
        [MessagePack.Key(111)]
        public float mHandBrake;                               // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]

        // additional race variables
        [MessagePack.Key(112)]
        public float[] mCurrentSector1Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(113)]
        public float[] mCurrentSector2Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(114)]
        public float[] mCurrentSector3Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(115)]
        public float[] mFastestSector1Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(116)]
        public float[] mFastestSector2Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(117)]
        public float[] mFastestSector3Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(118)]
        public float[] mFastestLapTimes = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(119)]
        public float[] mLastLapTimes = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(120)]
        public bool[] mLapsInvalidated = new bool[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];            // [ UNITS = boolean for all participants ]   [ RANGE = false->true ]   [ UNSET = false ]
        [MessagePack.Key(121)]
        public RaceState[] mRaceStates = new RaceState[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];         // [ enum (Type#3) Race State ]
        [MessagePack.Key(122)]
        public PitMode[] mPitModes = new PitMode[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];           // [ enum (Type#7)  Pit Mode ]
        [MessagePack.Key(123)]
        public float[,] mOrientations = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, (int)Vector.VEC_MAX];      // [ UNITS = Euler Angles ]
        [MessagePack.Key(124)]
        public float[] mSpeeds = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                     // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
        [MessagePack.Key(125)]
        public char[,] mCarNames = new char[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]
        [MessagePack.Key(126)]
        public char[,] mCarClassNames = new char[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]

        [MessagePack.Key(127)]                                                                                                  // additional race variables
        public int mEnforcedPitStopLap;                          // [ UNITS = in which lap there will be a mandatory pitstop] [ RANGE = 0.0f->... ] [ UNSET = -1 ]
        [MessagePack.Key(128)]
        public char[] mTranslatedTrackLocation = new char[SharedMemoryConsts.STRING_LENGTH_MAX];  // [ string ]
        [MessagePack.Key(129)]
        public char[] mTranslatedTrackVariation = new char[SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]
        [MessagePack.Key(130)]
        public float mBrakeBias;                                                                       // [ RANGE = 0.0f->1.0f... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(131)]
        public float mTurboBoostPressure;                                                  //	 RANGE = 0.0f->1.0f... ]   [ UNSET = -1.0f ]
        [MessagePack.Key(132)]
        public string[] mTyreCompound= new string[(int)Tyres.TYRE_MAX];// [ strings  ]
        [MessagePack.Key(133)]
        public PitMode[] mPitSchedules = new PitMode[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];  // [ enum (Type#7)  Pit Mode ]
        [MessagePack.Key(134)]
        public FlagColours[] mHighestFlagColours = new FlagColours[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                 // [ enum (Type#5) Flag Colour ]
        [MessagePack.Key(135)]
        public FlagReason[] mHighestFlagReasons = new FlagReason[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                 // [ enum (Type#6) Flag Reason ]
        [MessagePack.Key(136)]
        public UInt32[] mNationalities = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                                         // [ nationality table , SP AND UNSET = 0 ]
        [MessagePack.Key(137)]
        public float mSnowDensity;                                                             // [ UNITS = How much snow will fall ]   [ RANGE = 0.0f->1.0f ], this is non zero only in Winter and Snow seasons

        // AMS2 Additions (v10...)

        // Session info
        [MessagePack.Key(138)]
        public float mSessionDuration;           // [ UNITS = minutes ]   [ UNSET = 0.0f ]  The scheduled session Length (unset means laps race. See mLapsInEvent)
        [MessagePack.Key(139)]
        public int mSessionAdditionalLaps;     // The number of additional complete laps lead lap drivers must complete to finish a timed race after the session duration has elapsed.

        // Tyres
        [MessagePack.Key(140)]
        public float[] mTyreTempLeft = new float[(int)Tyres.TYRE_MAX];    // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        [MessagePack.Key(141)]
        public float[] mTyreTempCenter = new float[(int)Tyres.TYRE_MAX];  // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        [MessagePack.Key(142)]
        public float[] mTyreTempRight = new float[(int)Tyres.TYRE_MAX];   // [ UNITS = Celsius ]   [ UNSET = 0.0f ]

        // DRS
        [MessagePack.Key(143)]
        public UInt32 mDrsState;           // [ enum (Type#14) DrsState ]

        // Suspension
        [MessagePack.Key(144)]
        public float[] mRideHeight = new float[(int)Tyres.TYRE_MAX];      // [ UNITS = cm ]

        // Input
        [MessagePack.Key(145)]
        public UInt32 mJoyPad0;            // button mask
        [MessagePack.Key(146)]
        public UInt32 mDPad;               // button mask

        [MessagePack.Key(147)]
        public int mAntiLockSetting;             // [ UNSET = -1 ] Current ABS garage setting. Valid under player control only.
        [MessagePack.Key(148)]
        public int mTractionControlSetting;      // [ UNSET = -1 ] Current ABS garage setting. Valid under player control only.

        // ERS
        [MessagePack.Key(149)]
        public int mErsDeploymentMode;           // [ enum (Type#15)  ErsDeploymentMode ]
        [MessagePack.Key(150)]
        public bool mErsAutoModeEnabled;         // true if the deployment mode was selected by auto system. Valid only when mErsDeploymentMode > ERS_DEPLOYMENT_MODE_NONE

        // Clutch State & Damage
        [MessagePack.Key(151)]
        public float mClutchTemp;                // [ UNITS = Kelvin ] [ UNSET = -273.16 ]
        [MessagePack.Key(152)]
        public float mClutchWear;                // [ RANGE = 0.0f->1.0f... ]
        [MessagePack.Key(153)]
        public bool mClutchOverheated;          // true if clutch performance is degraded due to overheating
        [MessagePack.Key(154)]
        public bool mClutchSlipping;            // true if clutch is slipping (can be induced by overheating or wear)
        [MessagePack.Key(155)]
        public YellowFlagState mYellowFlagState;             // [ enum (Type#16) YellowFlagState ]
        [MessagePack.Key(156)]
        public bool mSessionIsPrivate;           // true if this is a private session where users cannot see or interact with other drivers (and so would not need positional awareness of them etc)
        [MessagePack.Key(157)]
        public LaunchStage mLaunchStage;                 // [ enum (Type#17) LaunchStage

        [SerializationConstructor]
        public SharedMemory()
        {

        }

        public SharedMemory(BinaryReader br)
        {
            mVersion = br.ReadUInt32();
            mBuildVersionNumber = br.ReadUInt32();
            mGameState = (GameState)br.ReadUInt32();
            mSessionState = (SessionState)br.ReadUInt32();                      // [ enum (Type#2) Session state ]
            mRaceState = (RaceState)br.ReadUInt32();

            mViewedParticipantIndex = br.ReadInt32();
            mNumParticipants = br.ReadInt32();
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mParticipantInfo[i] = new ParticipantInfo(br);
            }

            mUnfilteredThrottle = br.ReadSingle();
            mUnfilteredBrake = br.ReadSingle();
            mUnfilteredSteering = br.ReadSingle();
            mUnfilteredClutch = br.ReadSingle();

            mCarName = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            mCarClassName = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);

            mLapsInEvent = br.ReadUInt32();
            mTrackLocation = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            mTrackVariation = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            mTrackLength = br.ReadSingle();

            mNumSectors = br.ReadInt32();
            mLapInvalidated = br.ReadBoolean();
            br.ReadBytes(3); // 3 Empty bytes for alignment reasons.
            // Last working value above?
            mBestLapTime = br.ReadSingle();
            mLastLapTime = br.ReadSingle();
            mCurrentTime = br.ReadSingle();
            mSplitTimeAhead = br.ReadSingle();
            mSplitTimeBehind = br.ReadSingle();
            mSplitTime = br.ReadSingle();
            mEventTimeRemaining = br.ReadSingle();
            mPersonalFastestLapTime = br.ReadSingle();
            mWorldFastestLapTime = br.ReadSingle();
            mCurrentSector1Time = br.ReadSingle();
            mCurrentSector2Time = br.ReadSingle();
            mCurrentSector3Time = br.ReadSingle();
            mFastestSector1Time = br.ReadSingle();
            mFastestSector2Time = br.ReadSingle();
            mFastestSector3Time = br.ReadSingle();
            mPersonalFastestSector1Time = br.ReadSingle();
            mPersonalFastestSector2Time = br.ReadSingle();
            mPersonalFastestSector3Time = br.ReadSingle();
            mWorldFastestSector1Time = br.ReadSingle();
            mWorldFastestSector2Time = br.ReadSingle();
            mWorldFastestSector3Time = br.ReadSingle();
            mHighestFlagColour = (FlagColours)br.ReadUInt32();
            mHighestFlagReason = (FlagReason)br.ReadUInt32();

            mPitMode = (PitMode)br.ReadUInt32();
            mPitSchedule = (PitSchedule)br.ReadUInt32();

            mCarFlags = (CarFlags)br.ReadUInt32();
            mOilTempCelsius = br.ReadSingle();
            mOilPressureKPa = br.ReadSingle();
            mWaterTempCelsius = br.ReadSingle();
            mWaterPressureKPa = br.ReadSingle();
            mFuelPressureKPa = br.ReadSingle();
            mFuelLevel = br.ReadSingle();
            mFuelCapacity = br.ReadSingle();
            mSpeed = br.ReadSingle();
            mRpm = br.ReadSingle();
            mMaxRPM = br.ReadSingle();
            mBrake = br.ReadSingle();
            mThrottle = br.ReadSingle();
            mClutch = br.ReadSingle();
            mSteering = br.ReadSingle();
            mGear = br.ReadInt32();
            mNumGears = br.ReadInt32();
            mOdometerKM = br.ReadSingle();
            mAntiLockActive = br.ReadBoolean();
            br.ReadBytes(3);
            // Last working?
            mLastOpponentCollisionIndex = br.ReadInt32();
            mLastOpponentCollisionMagnitude = br.ReadSingle();
            mBoostActive = br.ReadBoolean();
            br.ReadBytes(3);
            mBoostAmount = br.ReadSingle();

            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mOrientation[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mLocalVelocity[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mWorldVelocity[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mAngularVelocity[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mLocalAcceleration[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mWorldAcceleration[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Vector.VEC_MAX; i++)
            {
                mExtentsCentre[i] = br.ReadSingle();
            }

            for (int i = 0; i <(int)Tyres.TYRE_MAX; i++)
            {
                mTyreFlags[i] = (TyreFlags)br.ReadUInt32();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTerrain[i] = (TerrainMaterials)br.ReadUInt32();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreY[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreRPS[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreSlipSpeed[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreTemp[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreGrip[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreHeightAboveGround[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreLateralStiffness[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreWear[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mBrakeDamage[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mSuspensionDamage[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mBrakeTempCelsius[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreTreadTemp[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreLayerTemp[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreCarcassTemp[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreRimTemp[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreInternalAirTemp[i] = br.ReadSingle();
            }

            mCrashState = (CrashDamage)br.ReadUInt32();
            mAeroDamage = br.ReadSingle();
            mEngineDamage = br.ReadSingle();

            mAmbientTemperature = br.ReadSingle();
            mTrackTemperature = br.ReadSingle();
            mRainDensity = br.ReadSingle();
            mWindSpeed = br.ReadSingle();
            mWindDirectionX = br.ReadSingle();
            mWindDirectionY = br.ReadSingle();
            mCloudBrightness = br.ReadSingle();

            mSequenceNumber = br.ReadUInt32();

            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mWheelLocalPositionY[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mSuspensionTravel[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mSuspensionVelocity[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mAirPressure[i] = br.ReadSingle();
            }
            mEngineSpeed = br.ReadSingle();
            mEngineTorque = br.ReadSingle();
            mWings[0] = br.ReadSingle();
            mWings[1] = br.ReadSingle();
            mHandBrake = br.ReadSingle();

            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mCurrentSector1Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mCurrentSector2Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mCurrentSector3Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mFastestSector1Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mFastestSector2Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mFastestSector3Times[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mFastestLapTimes[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mLastLapTimes[i] = br.ReadSingle();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mLapsInvalidated[i] = br.ReadBoolean();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mRaceStates[i] = (RaceState)br.ReadUInt32();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mPitModes[i] = (PitMode)br.ReadUInt32();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                for (int j = 0; j < (int)Vector.VEC_MAX; j++)
                {
                    mOrientations[i,j] = br.ReadSingle();
                }
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mSpeeds[i] = br.ReadSingle();
            }
            // TODO: Refactor these to not be char by char
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                for (int j = 0; j < SharedMemoryConsts.STRING_LENGTH_MAX; j++)
                {
                    mCarNames[i, j] = br.ReadChar();
                }
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                for (int j = 0; j < SharedMemoryConsts.STRING_LENGTH_MAX; j++)
                {
                    mCarClassNames[i, j] = br.ReadChar();
                }
            }

            mEnforcedPitStopLap = br.ReadInt32();
            mTranslatedTrackLocation = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            mTranslatedTrackVariation = br.ReadChars(SharedMemoryConsts.STRING_LENGTH_MAX);
            mBrakeBias = br.ReadSingle();
            mTurboBoostPressure = br.ReadSingle();
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreCompound[i] = new String(br.ReadChars(SharedMemoryConsts.TYRE_COMPOUND_NAME_LENGTH_MAX));
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mPitSchedules[i] = (PitMode)br.ReadInt32();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mHighestFlagColours[i] = (FlagColours)br.ReadInt32();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mHighestFlagReasons[i] = (FlagReason)br.ReadInt32();
            }
            for (int i = 0; i < SharedMemoryConsts.STORED_PARTICIPANTS_MAX; i++)
            {
                mNationalities[i] = br.ReadUInt32();
            }
            mSnowDensity = br.ReadSingle();

            mSessionDuration = br.ReadSingle();
            mSessionAdditionalLaps = br.ReadInt32();

            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreTempLeft[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreTempCenter[i] = br.ReadSingle();
            }
            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mTyreTempRight[i] = br.ReadSingle();
            }

            mDrsState = br.ReadUInt32();

            for (int i = 0; i < (int)Tyres.TYRE_MAX; i++)
            {
                mRideHeight[i] = br.ReadSingle();
            }

            mJoyPad0 = br.ReadUInt32();
            mDPad = br.ReadUInt32();

            mAntiLockSetting = br.ReadInt32();
            mTractionControlSetting = br.ReadInt32();

            mErsDeploymentMode = br.ReadInt32();
            mErsAutoModeEnabled = br.ReadBoolean();
            br.ReadBytes(3);

            mClutchTemp = br.ReadSingle();
            mClutchWear = br.ReadSingle();
            mClutchOverheated = br.ReadBoolean();
            br.ReadBytes(3);
            mClutchSlipping = br.ReadBoolean();
            br.ReadBytes(3);

            mYellowFlagState = (YellowFlagState)br.ReadInt32();

            mSessionIsPrivate = br.ReadBoolean();
            mLaunchStage = (LaunchStage)br.ReadInt32();

        }
    }
}
