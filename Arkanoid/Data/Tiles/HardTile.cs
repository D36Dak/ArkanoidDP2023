using Arkanoid.Data.Tiles.Decorator;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class HardTile : Tile
    {
        public HardTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
        {
        }

        public override void OnHit(Component tile, Ball ball)
        {
            // just bounce off
            var bounceDir = Linear.GetBounceOffDirection(this, ball);
            if (bounceDir == BounceDir.Horizontal) ball.InvertX();
            else ball.InvertY();
        }

        public override Component Clone()
        {
            //return new HardTile(Ball, Color, Position);
            return (HardTile)this.MemberwiseClone();
        }
    }

}
