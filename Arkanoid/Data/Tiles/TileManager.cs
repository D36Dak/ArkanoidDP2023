using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data.Tiles
{
    public class TileManager
    {
        public List<Tile> tiles = new();
        public readonly HubConnection Connection;
        
        public TileManager(HubConnection hub)
        {
            Connection = hub;
            hub.On<float, float>("ReceiveRemoveTile", (x, y) =>
            {
                var tile = tiles.Find(w => w.Position.X == x && w.Position.Y == y);
                if(tile != null)
                {
                    tiles.Remove(tile);
                }
            });
            hub.On<float, float, string>("ReceiveTileColor", (x, y, col) =>
            {
                var tile = tiles.Find(w => w.Position.X == x && w.Position.Y == y);
                if(tile != null) tile.Color = col;
            });
        }

        public async Task DestroyTile(Tile tile)
        {
            GameEngine.GetInstance().RemoveTileFromCollisions(tile);
            await Connection.SendAsync("RemoveTile", tile.Position.X, tile.Position.Y, Connection.ConnectionId);
        }

    }
}
