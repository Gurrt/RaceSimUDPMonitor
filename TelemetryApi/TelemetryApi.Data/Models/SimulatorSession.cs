using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    public class SimulatorSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Driver Driver { get; set; } = null!;

        [Required]
        public Simulator Simulator { get; set; } = null!;

        [Required]
        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
