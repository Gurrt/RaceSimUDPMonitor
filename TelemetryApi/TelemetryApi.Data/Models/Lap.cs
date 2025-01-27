using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    public class Lap
    {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; } = null!;
        public DateTime CompletedAt { get; set; }
        public int Number { get; set; }
        public float TotalTime { get; set; }
        public float Sector1Time { get; set; }
        public float Sector2Time { get; set; }
        public float Sector3Time { get; set; }
        public bool Valid { get; set; } = true;
    }
}
