using Arkanoid.Data;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Arkanoid.Hubs
{
    public class GameHub:Hub
    {
        private static List<Player> players = new List<Player>();
        public async Task SendPosition(int x, int y, string tag)
        {
            await Clients.All.SendAsync("ReceivePosition", x, y, tag);
        }

        public async Task SetPlayerPosition(int x, Side side)
        {
            await Clients.All.SendAsync("ReceivePlayerPosition", x, side);
        }
        public async Task Subscribe(string id)
        {
            if (players.Count >= 2)
            {
                return;
            }
            Console.WriteLine($"Connected: {id}");
            Side side = Side.LEFT;
            if (players.Count == 1)
            {
                if (players[0].side == Side.LEFT)
                    side = Side.RIGHT;
            }

            players.Add(new Player(id, side));
            Console.WriteLine($"Player count: {players.Count}");

            await Clients.All.SendAsync("PlayerJoin", id, side);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // problem if multiple players join at the same time threading problem.
            //if(players.Count >= 2)
            //{
            //    return;
            //}
            //string id = Context.ConnectionId;
            //Console.WriteLine($"Connected: {id}");
            //Side side = Side.LEFT;
            //if(players.Count == 1) 
            //{
            //    if (players[0].side == Side.LEFT)
            //        side = Side.RIGHT;
            //}
            
            //players.Add(new Player(id, side));
            //Console.WriteLine($"Player count: {players.Count}");

            //await Clients.All.SendAsync("PlayerJoin", id, side);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string id = Context.ConnectionId;
            Console.WriteLine($"Disconnected {id}. {exception?.Message}");
            Player? p = players.Find(w => w.id == id);
            await base.OnDisconnectedAsync(exception);
            if( p != null )
            {
                players.Remove(p);
                await Clients.All.SendAsync("PlayerLeft", id, p.side);
            }
        }
    }
}
