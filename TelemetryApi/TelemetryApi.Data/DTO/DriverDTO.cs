using TelemetryApi.Data.Models;

namespace TelemetryApi.Data.DTO
{
    public record DriverDTO(int Id, string Name)
    {
        public static DriverDTO FromModel(Driver driver) => new(driver.Id, driver.Name);
    }
} 