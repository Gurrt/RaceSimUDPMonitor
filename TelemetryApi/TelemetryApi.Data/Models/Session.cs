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
    [Index(nameof(Driver), IsUnique = false)]
    [Index(nameof(Simulator), IsUnique = false)]
    [Index(nameof(Track), IsUnique = false)]
    [Index(nameof(Car), IsUnique = false)]
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Driver Driver { get; set; } = null!;

        [Required]
        public Simulator Simulator { get; set; } = null!;

        [Required]
        public Track Track { get; set; } = null!;

        [Required]
        public Car Car { get; set; } = null!;

        [Required]
        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
