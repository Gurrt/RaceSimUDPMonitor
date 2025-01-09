using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryApi.Data.Models;

namespace TelemetryApi.Web.Data
{
    public class TelemetryApiWebContext : DbContext
    {
        public TelemetryApiWebContext (DbContextOptions<TelemetryApiWebContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetryApi.Data.Models.Simulator> Simulator { get; set; } = default!;
    }
}
