using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TelemetryApi.Data.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        public string SimulatorId { get; set; }
        public Simulator Simulator { get; set; } = null!;
        public int TrackId { get; set; }
        public Track Track { get; set; } = null!;
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public bool Active { get; set; }
        public DateTime? EndedAt { get; set; }
    }
}
