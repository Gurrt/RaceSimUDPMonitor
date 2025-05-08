using System.Net.Http.Json;
using TelemetryApi.Data.DTO;

namespace TelemetryApi.Web;

public class DriverApiClient
{
    private readonly HttpClient _httpClient;

    public DriverApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DriverDTO>> GetDriversAsync()
    {
        try
        {
            var drivers = await _httpClient.GetFromJsonAsync<List<DriverDTO>>("/drivers");
            return drivers ?? new List<DriverDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching drivers: {ex.Message}");
            return new List<DriverDTO>();
        }
    }

    public async Task<DriverDTO> GetDriverAsync(int id)
    {
        try
        {
            DriverDTO driver = await _httpClient.GetFromJsonAsync<DriverDTO>($"/drivers/{id}");
            return driver ?? new DriverDTO(0, String.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching drivers: {ex.Message}");
            return new DriverDTO(0, String.Empty);
        }
    }

    public async Task<DriverDTO?> AddDriverAsync(string name)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/drivers", new { Name = name });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DriverDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding driver: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteDriverAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"/drivers/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting driver: {ex.Message}");
            return false;
        }
    }
}
public record DriverDTO(int Id, string Name)
{
}