using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
        {
        }

        public override void OnHit(Tile tile, Ball ball)
        {
            // fix singleton for GameEngine first
            var bounceDir = Linear.GetBounceOffDirection(this, ball);
            GameEngine.GetInstance().InvertBallDirection(bounceDir);
            // destroy this tile. cheap but effective
            Console.WriteLine(bounceDir);
            GameEngine.GetInstance().DestroyTile(this);
        }
    }
}
