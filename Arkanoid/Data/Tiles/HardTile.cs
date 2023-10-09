using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class HardTile : Tile
    {
        public HardTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
        {
        }

        public override void OnHit()
        {
            // just bounce off
            var bounceDir = GetBounceOffDirection();
            if (bounceDir == BounceDir.Horizontal) ball.InvertX();
            else ball.InvertY();
        }
    }
}
