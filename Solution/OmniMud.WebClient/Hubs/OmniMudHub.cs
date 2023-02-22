using Microsoft.AspNetCore.SignalR;

namespace OmniMud.WebClient.Hubs
{
    public class OmniMudHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
