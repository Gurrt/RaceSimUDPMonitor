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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarClass>()
                .HasMany(e => e.Cars)
                .WithOne(e => e.Class)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Lap>()
                .HasOne(e => e.Session)
                .WithMany(e => e.Laps)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Sessions)
                .WithOne(e => e.Car)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Sessions)
                .WithOne(e => e.Driver)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.Sessions)
                .WithOne(e => e.Track)
                .HasPrincipalKey(e => e.Id);


            modelBuilder.Entity<Simulator>()
                .HasMany(e => e.Sessions)
                .WithOne(e => e.Simulator)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Simulator>()
                .HasOne(e => e.CurrentDriver);
        }
    }
}
