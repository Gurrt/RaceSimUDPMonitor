using Microsoft.EntityFrameworkCore;
using TelemetryApi.Data.Models;

namespace TelemetryApi.Data.Contexts
{
    public class RacesimDbContext: DbContext
    {
        public DbSet<Simulator> Simulators { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarsClasses { get; set; }
        public DbSet<Lap> Laps { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public RacesimDbContext(DbContextOptions<RacesimDbContext> options) : base(options)
        {


        }
    }
}
