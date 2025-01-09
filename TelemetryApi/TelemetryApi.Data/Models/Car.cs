using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Class), IsUnique = false)]
    public sealed class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public CarClass Class { get; set; } = null!;
    }
}
