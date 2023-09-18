using Microsoft.AspNetCore.SignalR;

namespace Arkanoid.Hubs
{
    public class GameHub:Hub
    {
        public async Task SendPosition(int x, int y, string tag)
        {
            await Clients.All.SendAsync("ReceivePosition", x, y, tag);
        }
    }
}
