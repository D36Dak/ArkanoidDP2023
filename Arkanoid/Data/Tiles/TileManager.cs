using Arkanoid.Data.Tiles.Decorator;
using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data.Tiles
{
    public class TileManager
    {
        public List<Component> tiles = new();
        public readonly HubConnection Connection;
        
        public TileManager(HubConnection hub)
        {
            Connection = hub;
            //hub.On<float, float>("ReceiveRemoveTile", (x, y) =>
            //{
            //    foreach(var comp in tiles)
            //    {
            //        if (comp.Position.X == x && comp.Position.Y == y)
            //        {
            //            Console.WriteLine("Removed tile " + x + ", " + y);
            //            tiles.Remove(comp);
            //        }
            //    }
            //});
            //hub.On<float, float, string>("ReceiveTileColor", (x, y, col) =>
            //{
            //    var tile = tiles.Find(w => w.Position.X == x && w.Position.Y == y);
            //    if(tile != null) tile.Color = col;
            //});
        }
        public void RemoveTile(Component tile)
        {
            foreach (var comp in tiles)
            {
                if (comp.Position.X == tile.Position.X && comp.Position.Y == tile.Position.Y)
                {
                    Console.WriteLine("Removed tile " + tile.Position.X + ", " + tile.Position.Y);
                    tiles.Remove(comp);
                }
            }
        }
        public async Task DestroyTile(Component tile)
        {
            GameEngine.GetInstance().RemoveTileFromCollisions(tile);
            RemoveTile(tile);
            //await Connection.SendAsync("RemoveTile", tile.Position.X, tile.Position.Y, Connection.ConnectionId);
        }

    }
}
