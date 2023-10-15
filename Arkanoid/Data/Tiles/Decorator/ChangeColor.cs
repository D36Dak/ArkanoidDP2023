using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data.Tiles.Decorator
{
    public class ChangeColor : Decorator
    {
        readonly string[] colors = { "blue", "red", "green", "orange", "yellow", "cyan", "gray" };
        readonly Random random = new();
        
        public override void OnHit(Tile tile, Ball ball)
        {
            base.OnHit(tile, ball);
            tile.Color = colors[random.Next(colors.Length)];
            //tile.TileManager.Connection.SendAsync("TileColor", tile.Position.X, tile.Position.Y, colors[random.Next(0, colors.Length)], tile.TileManager.Connection.ConnectionId);

        }
    }
}
