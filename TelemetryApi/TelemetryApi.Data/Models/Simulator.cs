using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Data.Models
{
    public sealed class Simulator
    {
        [Key]
        public string Identifier { get; set; } = "";
        [Required]
        public string FriendlyName { get; set; } = "";

        public long NumSessions { get; set; } = 0;
    }
}
