using Ams2SharedComponents;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TelemetryApi.ApiService.Hubs;
using TelemetryApi.ApiService.Interfaces;
using TelemetryApi.Data.Contexts;
using TelemetryApi.Data.Models;

namespace TelemetryApi.ApiService.Services
{
    // TODO: Definitely not thread safe, could cause some clashes when many telemetry packets are coming in.
    // Might want to create a handler thread and a queue to enforce thread safety.
    public class SimulatorSessionTrackingService(RacesimDbContext context, IHubContext<RealtimeTelemetryHub> signalRHub) : ISimulatorSessionTrackingService
    {
        private static readonly TimeSpan MAX_INVALIDATE_SPAN = new(0, 5, 0); // 5 Minutes

        private static readonly HashSet<string> ValidatedSimulatorIds = [];
        private static readonly HashSet<string> InvalidSimulatorIds = [];
        private static readonly Dictionary<string, DateTime> lastPacketPerSim = [];
        private static readonly Dictionary<string, Session> sessionPerSim = [];

        private static readonly Dictionary<Session, float> lastLaptimePerSession = [];
        private static readonly Dictionary<Session, bool> nextLapInvalidated = [];
        private static readonly Dictionary<Session, int> lapCounter = [];

        private static DateTime lastCheckedAt = DateTime.MinValue;

        private readonly RacesimDbContext racesimDbContext = context;
        private readonly IHubContext<RealtimeTelemetryHub> hub = signalRHub;

        public Session? GetSession(string simulatorId)
        {
            if (sessionPerSim.TryGetValue(simulatorId, out Session? value))
            {
                return value;
            }

            if (!SimulatorIdIsValid(simulatorId, DateTime.UtcNow))
            {
                throw new ArgumentException($"SimulatorId {simulatorId} invalid.");
            }

            Simulator? sim = racesimDbContext.Simulators.Where(s => s.Id == simulatorId).FirstOrDefault();
            Session? session = racesimDbContext.Sessions.Where(s => s.Simulator == sim && s.Active).FirstOrDefault();
            if (session != default && session != null)
            {
                sessionPerSim[simulatorId] = session;
            }
            
            return session;
        }

        public void IngestTelemetry(SharedMemory sharedMemory, string simulatorId)
        {
            DateTime now = DateTime.UtcNow;
            if (!SimulatorIdIsValid(simulatorId, now))
            {
                return;
            }

            lastPacketPerSim[simulatorId] = now;
            Session? session = GetSession(simulatorId);
            if (session == default || session == null)
            {
                session = CreateSessionForTelemetry(sharedMemory, simulatorId, now);
            }
            CheckLaptime(session, sharedMemory, now);
        }

        private void CheckLaptime(Session session, SharedMemory memory, DateTime now)
        {
            if (memory.mLapInvalidated)
            {
                nextLapInvalidated[session] = true;
            }

            // Different Laptime, passed start.
            if (memory.mLastLapTime > 0 && (!lastLaptimePerSession.TryGetValue(session, out float val) || val != memory.mLastLapTime))
            {
                int counter;
                if (lapCounter.TryGetValue(session, out counter))
                {
                    counter++;
                } else
                {
                    counter = 1;
                }
                lapCounter[session] = counter;

                Lap lap = new()
                {
                    CompletedAt = now,
                    Valid = nextLapInvalidated.ContainsKey(session) && nextLapInvalidated[session],
                    Number = counter,
                    Session = session,
                    TotalTime = memory.mLastLapTime,
                    Sector1Time = memory.mCurrentSector1Time,
                    Sector2Time = memory.mCurrentSector2Time,
                    Sector3Time = memory.mCurrentSector3Time,
                };

                racesimDbContext.Add(lap);
                nextLapInvalidated[session] = false;

                float lastKnownLaptime = memory.mLastLapTime;
                int minutes = (int)Math.Floor(lastKnownLaptime / 60);
                int seconds = (int)Math.Floor(lastKnownLaptime % 60);
                int miliseconds = (int)(1000 * (lastKnownLaptime - Math.Floor(lastKnownLaptime)));

                string secondsString = seconds < 10 ? "0" + seconds : seconds.ToString();
                string milisecondsString = miliseconds < 10 ? "00" + miliseconds :
                    miliseconds < 100 ? "0" + miliseconds :
                    miliseconds.ToString();

                string laptimeString = $"{minutes}:{secondsString}.{milisecondsString}";
                string loggingString = $"New lap from driver: {laptimeString}";
                Console.WriteLine(loggingString);

                hub.Clients.All.SendAsync("ReceiveMessage", "Race Control", loggingString);
                lastLaptimePerSession[session] = lastKnownLaptime;
            }
        }

        private Session CreateSessionForTelemetry(SharedMemory sharedMemory, string simulatorId, DateTime now)
        {
            Simulator? sim = racesimDbContext.Simulators
                .Include(s => s.CurrentDriver)
                .Where(s => s.Id == simulatorId)
                .FirstOrDefault();
            if (sim?.CurrentDriver == null)
            {
                throw new ArgumentException($"Simulator {simulatorId} does not have a Current Driver, can't log telemetry.");
            }

            Driver driver = sim.CurrentDriver;
            CarClass cc = GetCreateCarClass(StringFromCharArr(sharedMemory.mCarClassName));
            Car car = GetCreateCar(StringFromCharArr(sharedMemory.mCarName), cc);
            Track track = GetCreateTrack(StringFromCharArr(sharedMemory.mTrackLocation), StringFromCharArr(sharedMemory.mTrackVariation));
            Session newSession = new()
            {
                Active = true,
                Simulator = sim,
                Driver = driver,
                Car = car,
                Track = track,
                StartedAt = now,
            };

            racesimDbContext.Add(newSession);
            sessionPerSim[simulatorId] = newSession;
            return newSession;
        }

        private string StringFromCharArr(char[] charArr)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == '\0')
                {
                    return builder.ToString();
                }
                builder.Append(charArr[i]);
            }
            return builder.ToString();
        }

        private Track GetCreateTrack(string location, string variation)
        {
            Track? track = racesimDbContext.Tracks.Where(s => s.Location == location && s.Variation == variation).FirstOrDefault();
            if (track == default)
            {
                track = new Track()
                {
                    Location = location,
                    Variation = variation,
                };
                racesimDbContext.Add(track);
            }
            return track;
        }

        private CarClass GetCreateCarClass(string carClass)
        {
            CarClass? carClassEntity = racesimDbContext.CarsClasses.Where(cc => cc.Name == carClass).FirstOrDefault();
            if (carClassEntity == default)
            {
                carClassEntity = new CarClass()
                {
                    Name = carClass,
                };
                racesimDbContext.Add(carClassEntity);
            }
            return carClassEntity;
        }

        private Car GetCreateCar(string car, CarClass carClass)
        {
            Car carEntity = racesimDbContext.Cars.Where(c => c.Name == car && c.Class == carClass).FirstOrDefault();
            if (carEntity == default)
            {
                carEntity = new Car()
                {
                    Class = carClass,
                    Name = car,
                };
                racesimDbContext.Add(carEntity);
            }
            return carEntity;
        }

        // TODO: Definitely not thread safe, could cause some clashes when many telemetry packets are coming in.
        private bool SimulatorIdIsValid(string simulatorId, DateTime now)
        {
            // Checked already and exists.
            if (ValidatedSimulatorIds.Contains(simulatorId))
            {
                return true;
            }
            TimeSpan timeSinceLastcheck = now - lastCheckedAt;

            // Check if we already checked this Id within the current caching timespan.
            if (InvalidSimulatorIds.Contains(simulatorId) && timeSinceLastcheck < MAX_INVALIDATE_SPAN)
            {
                return false;
            }

            // No data for this Simulator Id or caching timespan ran out; check vs database.
            lastCheckedAt = now;
            InvalidSimulatorIds.Clear();

            Simulator[] matchingSims = racesimDbContext.Simulators.Where(s => s.Id == simulatorId).ToArray();
            if (matchingSims.Length > 0)
            {
                ValidatedSimulatorIds.Add(simulatorId);
                return true;
            }

            InvalidSimulatorIds.Add(simulatorId);
            return false;
        }
    }
}
