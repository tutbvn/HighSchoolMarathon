using Microsoft.AspNetCore.SignalR;

namespace HighSchoolMarathon.WebApp.Infrastructure
{
    public class MarathonEventHub : Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
