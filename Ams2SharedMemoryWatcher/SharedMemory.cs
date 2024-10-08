using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams2SharedMemoryWatcher
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

    public struct ParticipantInfo
    {
        bool mIsActive;
        char[] mName = new char[SharedMemoryConsts.STRING_LENGTH_MAX];                   // [ string ]
        float[] mWorldPosition = new float[(int) Vector.VEC_MAX];                   // [ UNITS = World Space  X  Y  Z ]
        float mCurrentLapDistance;                       // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]
        UInt32 mRacePosition;                      // [ RANGE = 1->... ]   [ UNSET = 0 ]
        UInt32 mLapsCompleted;                     // [ RANGE = 0->... ]   [ UNSET = 0 ]
        UInt32 mCurrentLap;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
        int mCurrentSector;                              // [ RANGE = 0->... ]   [ UNSET = -1 ]

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

    public struct SharedMemory
    {
        // Version Number
        public UInt32 mVersion;                           // [ RANGE = 0->... ]
        public UInt32 mBuildVersionNumber;                // [ RANGE = 0->... ]   [ UNSET = 0 ]

        // Game States
        public GameState mGameState;                         // [ enum (Type#1) Game state ]
        public SessionState mSessionState;                      // [ enum (Type#2) Session state ]
        public RaceState mRaceState;                         // [ enum (Type#3) Race State ]

        // Participant Info
        public int mViewedParticipantIndex;                                  // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        public int mNumParticipants;                                         // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        public ParticipantInfo[] mParticipantInfo = new ParticipantInfo[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];    // [ struct (Type#13) ParticipantInfo struct ]

        // Unfiltered Input
        public float mUnfilteredThrottle;                        // [ RANGE = 0.0f->1.0f ]
        public float mUnfilteredBrake;                           // [ RANGE = 0.0f->1.0f ]
        public float mUnfilteredSteering;                        // [ RANGE = -1.0f->1.0f ]
        public float mUnfilteredClutch;                          // [ RANGE = 0.0f->1.0f ]

        // Vehicle information
        char[] mCarName = new char[SharedMemoryConsts.STRING_LENGTH_MAX];                 // [ string ]
        char[] mCarClassName= new char[SharedMemoryConsts.STRING_LENGTH_MAX];            // [ string ]

        // Event information
        public UInt32 mLapsInEvent;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
        public char[] mTrackLocation= new char[SharedMemoryConsts.STRING_LENGTH_MAX];           // [ string ] - untranslated shortened English name
        public char[] mTrackVariation= new char[SharedMemoryConsts.STRING_LENGTH_MAX];          // [ string ]- untranslated shortened English variation description
        public float mTrackLength;                               // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]

        // Timings
        public int mNumSectors;                                  // [ RANGE = 0->... ]   [ UNSET = -1 ]
        public bool mLapInvalidated;                             // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        public float mBestLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mLastLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mCurrentTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mSplitTimeAhead;                            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mSplitTimeBehind;                           // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mSplitTime;                                 // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mEventTimeRemaining;                        // [ UNITS = milli-seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mPersonalFastestLapTime;                    // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mWorldFastestLapTime;                       // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mCurrentSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mCurrentSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mCurrentSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mFastestSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mFastestSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mFastestSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mPersonalFastestSector1Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mPersonalFastestSector2Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mPersonalFastestSector3Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mWorldFastestSector1Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mWorldFastestSector2Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float mWorldFastestSector3Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]

        // Flags
        public UInt32 mHighestFlagColour;                 // [ enum (Type#5) Flag Colour ]
        public UInt32 mHighestFlagReason;                 // [ enum (Type#6) Flag Reason ]

        // Pit Info
        public UInt32 mPitMode;                           // [ enum (Type#7) Pit Mode ]
        public UInt32 mPitSchedule;                       // [ enum (Type#8) Pit Stop Schedule ]

        // Car State
        public UInt32 mCarFlags;                          // [ enum (Type#9) Car Flags ]
        public float mOilTempCelsius;                           // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float mOilPressureKPa;                           // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mWaterTempCelsius;                         // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float mWaterPressureKPa;                         // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mFuelPressureKPa;                          // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mFuelLevel;                                // [ RANGE = 0.0f->1.0f ]
        public float mFuelCapacity;                             // [ UNITS = Liters ]   [ RANGE = 0.0f->1.0f ]   [ UNSET = 0.0f ]
        public float mSpeed;                                    // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
        public float mRpm;                                      // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mMaxRPM;                                   // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float mBrake;                                    // [ RANGE = 0.0f->1.0f ]
        public float mThrottle;                                 // [ RANGE = 0.0f->1.0f ]
        public float mClutch;                                   // [ RANGE = 0.0f->1.0f ]
        public float mSteering;                                 // [ RANGE = -1.0f->1.0f ]
        public int mGear;                                       // [ RANGE = -1 (Reverse)  0 (Neutral)  1 (Gear 1)  2 (Gear 2)  etc... ]   [ UNSET = 0 (Neutral) ]
        public int mNumGears;                                   // [ RANGE = 0->... ]   [ UNSET = -1 ]
        public float mOdometerKM;                               // [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public bool mAntiLockActive;                            // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        public int mLastOpponentCollisionIndex;                 // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        public float mLastOpponentCollisionMagnitude;           // [ RANGE = 0.0f->... ]
        public bool mBoostActive;                               // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        public float mBoostAmount;                              // [ RANGE = 0.0f->100.0f ] 

        // Motion & Device Related
        public float[] mOrientation = new float[(int)Vector.VEC_MAX];                     // [ UNITS = Euler Angles ]
        public float[] mLocalVelocity = new float[(int)Vector.VEC_MAX];                  // [ UNITS = Metres per-second ]
        public float[] mWorldVelocity = new float[(int)Vector.VEC_MAX];                  // [ UNITS = Metres per-second ]
        public float[] mAngularVelocity = new float[(int)Vector.VEC_MAX];                 // [ UNITS = Radians per-second ]
        public float[] mLocalAcceleration = new float[(int)Vector.VEC_MAX];               // [ UNITS = Metres per-second ]
        public float[] mWorldAcceleration = new float[(int)Vector.VEC_MAX];                // [ UNITS = Metres per-second ]
        public float[] mExtentsCentre = new float[(int)Vector.VEC_MAX];                    // [ UNITS = Local Space  X  Y  Z ]

        // Wheels / Tyres
        public UInt32[] mTyreFlags = new UInt32[(int)Tyres.TYRE_MAX];               // [ enum (Type#10) Tyre Flags ]
        public UInt32[] mTerrain = new UInt32[(int)Tyres.TYRE_MAX];                 // [ enum (Type#11) Terrain Materials ]
        public float[] mTyreY = new float[(int)Tyres.TYRE_MAX];                          // [ UNITS = Local Space  Y ]
        public float[] mTyreRPS = new float[(int)Tyres.TYRE_MAX];                        // [ UNITS = Revolutions per second ]
        public float[] mTyreSlipSpeed = new float[(int)Tyres.TYRE_MAX];                  // OBSOLETE, kept for backward compatibility only
        public float[] mTyreTemp = new float[(int)Tyres.TYRE_MAX];                       // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float[] mTyreGrip = new float[(int)Tyres.TYRE_MAX];                       // OBSOLETE, kept for backward compatibility only
        public float[] mTyreHeightAboveGround = new float[(int)Tyres.TYRE_MAX];          // [ UNITS = Local Space  Y ]
        public float[] mTyreLateralStiffness = new float[(int)Tyres.TYRE_MAX];           // OBSOLETE, kept for backward compatibility only
        public float[] mTyreWear = new float[(int)Tyres.TYRE_MAX];                       // [ RANGE = 0.0f->1.0f ]
        public float[] mBrakeDamage = new float[(int)Tyres.TYRE_MAX];                    // [ RANGE = 0.0f->1.0f ]
        public float[] mSuspensionDamage = new float[(int)Tyres.TYRE_MAX];               // [ RANGE = 0.0f->1.0f ]
        public float[] mBrakeTempCelsius = new float[(int)Tyres.TYRE_MAX];               // [ UNITS = Celsius ]
        public float[] mTyreTreadTemp = new float[(int)Tyres.TYRE_MAX];                  // [ UNITS = Kelvin ]
        public float[] mTyreLayerTemp = new float[(int)Tyres.TYRE_MAX];                  // [ UNITS = Kelvin ]
        public float[] mTyreCarcassTemp = new float[(int)Tyres.TYRE_MAX];                // [ UNITS = Kelvin ]
        public float[] mTyreRimTemp = new float[(int)Tyres.TYRE_MAX];                    // [ UNITS = Kelvin ]
        public float[] mTyrepublicAirTemp = new float[(int)Tyres.TYRE_MAX];            // [ UNITS = Kelvin ]

        // Car Damage
        public UInt32 mCrashState;                        // [ enum (Type#12) Crash Damage State ]
        public float mAeroDamage;                               // [ RANGE = 0.0f->1.0f ]
        public float mEngineDamage;                             // [ RANGE = 0.0f->1.0f ]

        // Weather
        public float mAmbientTemperature;                       // [ UNITS = Celsius ]   [ UNSET = 25.0f ]
        public float mTrackTemperature;                         // [ UNITS = Celsius ]   [ UNSET = 30.0f ]
        public float mRainDensity;                              // [ UNITS = How much rain will fall ]   [ RANGE = 0.0f->1.0f ]
        public float mWindSpeed;                                // [ RANGE = 0.0f->100.0f ]   [ UNSET = 2.0f ]
        public float mWindDirectionX;                           // [ UNITS = Normalised Vector X ]
        public float mWindDirectionY;                           // [ UNITS = Normalised Vector Y ]
        public float mCloudBrightness;                          // [ RANGE = 0.0f->... ]

        //PCars2 additions start, version 8
        // Sequence Number to help slightly with data integrity reads
        public volatile UInt32 mSequenceNumber;          // 0 at the start, incremented at start and end of writing, so odd when Shared Memory is being filled, even when the memory is not being touched

        //Additional car variables
        public float[] mWheelLocalPositionY= new float[(int)Tyres.TYRE_MAX];           // [ UNITS = Local Space  Y ]
        public float[] mSuspensionTravel= new float[(int)Tyres.TYRE_MAX];              // [ UNITS = meters ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        public float[] mSuspensionVelocity= new float[(int)Tyres.TYRE_MAX];            // [ UNITS = Rate of change of pushrod deflection ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        public float[] mAirPressure= new float[(int)Tyres.TYRE_MAX];                   // [ UNITS = PSI ]  [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
        public float mEngineSpeed;                             // [ UNITS = Rad/s ] [UNSET = 0.f ]
        public float mEngineTorque;                            // [ UNITS = Newton Meters] [UNSET = 0.f ] [ RANGE = 0.0f->... ]
        public float[] mWings = new float[2];                                // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]
        public float mHandBrake;                               // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]

        // additional race variables
        public float[] mCurrentSector1Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mCurrentSector2Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mCurrentSector3Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mFastestSector1Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mFastestSector2Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mFastestSector3Times = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mFastestLapTimes = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public float[] mLastLapTimes = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public bool[] mLapsInvalidated = new bool[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];            // [ UNITS = boolean for all participants ]   [ RANGE = false->true ]   [ UNSET = false ]
        public UInt32[] mRaceStates = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];         // [ enum (Type#3) Race State ]
        public UInt32[] mPitModes = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];           // [ enum (Type#7)  Pit Mode ]
        public float[,] mOrientations = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, (int)Vector.VEC_MAX];      // [ UNITS = Euler Angles ]
	    public float[] mSpeeds = new float[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                     // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
        public char[,] mCarNames = new char[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]
        public char[,] mCarClassNames = new char[SharedMemoryConsts.STORED_PARTICIPANTS_MAX, SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]

																											// additional race variables
	    public int mEnforcedPitStopLap;                          // [ UNITS = in which lap there will be a mandatory pitstop] [ RANGE = 0.0f->... ] [ UNSET = -1 ]
        public char[] mTranslatedTrackLocation = new char[SharedMemoryConsts.STRING_LENGTH_MAX];  // [ string ]
        public char[] mTranslatedTrackVariation = new char[SharedMemoryConsts.STRING_LENGTH_MAX]; // [ string ]
        public float mBrakeBias;                                                                       // [ RANGE = 0.0f->1.0f... ]   [ UNSET = -1.0f ]
        public float mTurboBoostPressure;                                                  //	 RANGE = 0.0f->1.0f... ]   [ UNSET = -1.0f ]
        public char[,] mTyreCompound= new char[(int)Tyres.TYRE_MAX, SharedMemoryConsts.TYRE_COMPOUND_NAME_LENGTH_MAX];// [ strings  ]
	    public UInt32[] mPitSchedules = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];  // [ enum (Type#7)  Pit Mode ]
        public UInt32[] mHighestFlagColours = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                 // [ enum (Type#5) Flag Colour ]
        public UInt32[] mHighestFlagReasons = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                 // [ enum (Type#6) Flag Reason ]
        public UInt32[] mNationalities = new UInt32[SharedMemoryConsts.STORED_PARTICIPANTS_MAX];                                         // [ nationality table , SP AND UNSET = 0 ]
        public float mSnowDensity;                                                             // [ UNITS = How much snow will fall ]   [ RANGE = 0.0f->1.0f ], this is non zero only in Winter and Snow seasons

        // AMS2 Additions (v10...)

        // Session info
        public float mSessionDuration;           // [ UNITS = minutes ]   [ UNSET = 0.0f ]  The scheduled session Length (unset means laps race. See mLapsInEvent)
        public int mSessionAdditionalLaps;     // The number of additional complete laps lead lap drivers must complete to finish a timed race after the session duration has elapsed.

        // Tyres
        public float[] mTyreTempLeft = new float[(int)Tyres.TYRE_MAX];    // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float[] mTyreTempCenter = new float[(int)Tyres.TYRE_MAX];  // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float[] mTyreTempRight = new float[(int)Tyres.TYRE_MAX];   // [ UNITS = Celsius ]   [ UNSET = 0.0f ]

        // DRS
        public UInt32 mDrsState;           // [ enum (Type#14) DrsState ]

        // Suspension
        public float[] mRideHeight = new float[(int)Tyres.TYRE_MAX];      // [ UNITS = cm ]

        // Input
        public UInt32 mJoyPad0;            // button mask
        public UInt32 mDPad;               // button mask

        public int mAntiLockSetting;             // [ UNSET = -1 ] Current ABS garage setting. Valid under player control only.
        public int mTractionControlSetting;      // [ UNSET = -1 ] Current ABS garage setting. Valid under player control only.

        // ERS
        public int mErsDeploymentMode;           // [ enum (Type#15)  ErsDeploymentMode ]
        public bool mErsAutoModeEnabled;         // true if the deployment mode was selected by auto system. Valid only when mErsDeploymentMode > ERS_DEPLOYMENT_MODE_NONE

        // Clutch State & Damage
        public float mClutchTemp;                // [ UNITS = Kelvin ] [ UNSET = -273.16 ]
        public float mClutchWear;                // [ RANGE = 0.0f->1.0f... ]
        public bool mClutchOverheated;          // true if clutch performance is degraded due to overheating
        public bool mClutchSlipping;            // true if clutch is slipping (can be induced by overheating or wear)

        public int mYellowFlagState;             // [ enum (Type#16) YellowFlagState ]

        public bool mSessionIsPrivate;           // true if this is a private session where users cannot see or interact with other drivers (and so would not need positional awareness of them etc)
        public int mLaunchStage;                 // [ enum (Type#17) LaunchStage

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
        }
    }
}
