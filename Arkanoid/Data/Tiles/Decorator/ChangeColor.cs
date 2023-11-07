using Microsoft.AspNetCore.SignalR.Client;
using System.ComponentModel;
using System.Numerics;

namespace Arkanoid.Data.Tiles.Decorator
{
    public class ChangeColor : Decorator
    {
        readonly string[] colors = { "blue", "red", "purple", "orange", "yellow", "cyan", "green" };
        readonly Random random = new();

        public ChangeColor(Component component) : base(component)
        {
            Color = colors[HP];
        }

        public override void OnHit(Component tile, Ball ball)
        {
            base.OnHit(tile, ball);
            tile.Color = colors[tile.HP];
            Console.WriteLine($"HP left: {tile.HP} | {Color}");
            //tile.TileManager.Connection.SendAsync("TileColor", tile.Position.X, tile.Position.Y, colors[random.Next(0, colors.Length)], tile.TileManager.Connection.ConnectionId);

        }

        public override Component Clone()
        {
            //return new RegularTile(Ball, Color, Position, HP);
            Component c = (Component)this.MemberwiseClone();
            Ball.Attach(c);
            return c;
        }


        public override Component DeepCopy()
        {
            // Create a new instance using Clone() (which will handle value types)
            var newChangeColor = Clone();
            newChangeColor.Ball = new Ball(new GameWindow());
            newChangeColor.Color = string.Copy(this.Color);
            newChangeColor.Position = new Vector2(this.Position.X, this.Position.Y);
            return newChangeColor;
        }
    }
}
