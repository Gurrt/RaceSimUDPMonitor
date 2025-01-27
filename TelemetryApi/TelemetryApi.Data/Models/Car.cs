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
    public sealed class Car
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CarClassId { get; set; }
        public CarClass CarClass { get; set; } = null!;
    }
}
