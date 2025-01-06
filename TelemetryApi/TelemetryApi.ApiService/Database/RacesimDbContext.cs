using Microsoft.EntityFrameworkCore;
using TelemetryApi.ApiService.Domain;

namespace TelemetryApi.ApiService.Database
{
    public class RacesimDbContext: DbContext
    {
        public DbSet<Simulator> Simulators { get; set; }
        public RacesimDbContext(DbContextOptions<RacesimDbContext> options) : base(options)
        {

        }
    }
}
