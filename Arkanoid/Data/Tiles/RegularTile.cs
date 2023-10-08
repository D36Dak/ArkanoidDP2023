using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
        {
        }

        public override void OnHit()
        {
            // fix singleton for GameEngine first
        }
    }
}
