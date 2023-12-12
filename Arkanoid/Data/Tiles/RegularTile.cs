using Arkanoid.Data.Tiles.Decorator;
using Arkanoid.Data.Visitor;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position, int hp = 1) : base(ball, color, position, hp)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }   

        public override void BounceOff(Component tile, Ball ball)
        {
            var bounceDir = Linear.GetBounceOffDirection(tile, ball);
            GameEngine.GetInstance().InvertBallDirection(bounceDir);
        }

        public override bool NeedReduceHP(Component tile, Ball ball) => true;
        public override bool NeedDestroy(Component tile, Ball ball) => tile.HP <= 0;
        public override void ReduceHP(Component tile, Ball ball)
        {
            tile.HP = Math.Max(tile.HP - 1, 0);
        }
        public override void Destroy(Component tile, Ball ball)
        {
            Accept(GameEngine.GetInstance().visitor);
            GameEngine.GetInstance().tm?.DestroyTile(tile);
        }

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
