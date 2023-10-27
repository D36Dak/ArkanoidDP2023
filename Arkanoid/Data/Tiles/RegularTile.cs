using Arkanoid.Data.Tiles.Decorator;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position, int hp = 1) : base(ball, color, position, hp)
        {
        }

        public override void OnHit(Component tile, Ball ball)
        {
            // fix singleton for GameEngine first
            var bounceDir = Linear.GetBounceOffDirection(tile, ball);
            GameEngine.GetInstance().InvertBallDirection(bounceDir);
            // destroy this tile. cheap but effective
            //Console.WriteLine(bounceDir);
            tile.HP -= 1;
            if(tile.HP <= 0)
            {
                tile.HP = 0;
                GameEngine.GetInstance().tm?.DestroyTile(tile);
            }
        }

        //public override Component Clone()
        //{
        //    //return new RegularTile(Ball, Color, Position, HP);
        //    return (Component)this.MemberwiseClone();
        //}

        public override Component Clone()
        {
            Component c = (Component)this.MemberwiseClone();
            Ball.Attach(c);
            return c;
        }

        public override Component DeepCopy()
        {
            // Create a new instance using Clone() (which will handle value types)
            var newTile = Clone();

            // Create new instances of any internal reference types or deep clone them
            newTile.Ball = new Ball(new GameWindow());

            // Example of cloning a string (if needed)
            newTile.Color = string.Copy(this.Color);

            newTile.Position = new Vector2(this.Position.X, this.Position.Y);

            newTile.HP = this.HP;

            return newTile;
        }
    }
}
