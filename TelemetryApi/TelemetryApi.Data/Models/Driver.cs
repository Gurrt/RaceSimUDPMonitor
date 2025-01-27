using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public sealed class Driver
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
