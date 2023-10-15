using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class HardTile : Tile
    {
        public HardTile(Ball ball, string color, Vector2 position, TileManager tm) : base(ball, color, position, tm)
        {
        }

        public override void OnHit(Tile tile, Ball ball)
        {
            // just bounce off
            var bounceDir = Linear.GetBounceOffDirection(this, ball);
            if (bounceDir == BounceDir.Horizontal) ball.InvertX();
            else ball.InvertY();
        }
    }
}
