using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.ApiService.Domain
{
    public class Simulator
    {
        [Key]
        public string Identifier { get; set; } = "";
        public string FriendlyName { get; set; } = "";
    }
}
