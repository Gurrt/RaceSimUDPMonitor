using Microsoft.AspNetCore.SignalR;

namespace TelemetryApi.SignalRHub.Hubs
{
    public class RealtimeTelemetryHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine("Received message, sending back echo");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
