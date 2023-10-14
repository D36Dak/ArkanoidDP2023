using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position, TileManager tm) : base(ball, color, position, tm)
        {
        }

        public override void OnHit(Tile tile, Ball ball)
        {
            // fix singleton for GameEngine first
            var bounceDir = Linear.GetBounceOffDirection(this, ball);
            GameEngine.GetInstance().InvertBallDirection(bounceDir, TileManager.Connection.ConnectionId);
            // destroy this tile. cheap but effective
            //Console.WriteLine(bounceDir);
            //TileManager.DestroyTile(this);
        }
    }
}
