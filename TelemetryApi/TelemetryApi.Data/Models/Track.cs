using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelemetryApi.Data.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Variation { get; set; }

        public ICollection<Session> Sessions { get; }
    }
}
