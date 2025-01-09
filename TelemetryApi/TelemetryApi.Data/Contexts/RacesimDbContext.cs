using Microsoft.EntityFrameworkCore;
using TelemetryApi.Data.Models;

namespace TelemetryApi.Data.Contexts
{
    public class RacesimDbContext: DbContext
    {
        public DbSet<Simulator> Simulators { get; set; }
        public RacesimDbContext(DbContextOptions<RacesimDbContext> options) : base(options)
        {

        }
    }
}
