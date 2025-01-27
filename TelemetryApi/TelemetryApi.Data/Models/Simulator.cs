using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Data.Models
{
    public sealed class Simulator
    {
        [Key]
        public string Id { get; set; } = "";
        [Required]
        public string FriendlyName { get; set; } = "";

        public long NumSessions { get; set; } = 0;

        public int? CurrentDriverId { get; set; }
        public Driver? CurrentDriver { get; set; }
    }
}
