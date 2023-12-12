using Arkanoid.Data.Tiles.Decorator;
using Arkanoid.Data.Visitor;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class ExplodingTile : Tile
    {
        public ExplodingTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
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

        public override bool NeedDestroy(Component tile, Ball ball)
        {
            return true;
        }

        public override void Destroy(Component tile, Ball ball)
        {

            var GE = GameEngine.GetInstance();
            Accept(GE.visitor);
            var tilesInRadius = GE.GetTilesInRadius(tile, 200);
            foreach(var t in tilesInRadius)
            {
                GE.tm.DestroyTile(t);
            }
            GE.tm?.DestroyTile(tile);
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
            newTile.Color = string.Copy(this.Color);
            newTile.Position = new Vector2(this.Position.X, this.Position.Y);

            return newTile;
        }
       
    }
}
