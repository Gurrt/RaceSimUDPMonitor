using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    [Index(nameof(Session), IsUnique = false)]
    public class Lap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Session Session { get; set; } = null!;

        [Required]
        public DateTime CompletedAt { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public float TotalTime { get; set; }

        [Required]
        public float Sector1Time { get; set; }

        [Required]
        public float Sector2Time { get; set; }

        [Required]
        public float Sector3Time { get; set; }

        [Required]
        public bool Valid { get; set; } = true;
    }
}
