using Arkanoid.Data.PowerUps;
using Arkanoid.Data.Tiles.Decorator;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public abstract class Tile : Component, IObserver
    {

        public Tile(Ball ball, string color, Vector2 position, int hp = 1, Decorator.Decorator? decorator = null) : base(color, position, ball, decorator, hp)
        {
        }

        // template parameters
        public abstract void BounceOff(Component tile, Ball ball);
        public virtual void ReduceHP(Component tile, Ball ball) { }
        public virtual bool NeedReduceHP(Component tile, Ball ball) { return false; }
        public virtual bool NeedDestroy(Component tile, Ball ball) { return false; }
        public virtual void Destroy(Component tile, Ball ball) { }

        // template method
        public override sealed void OnHit(Component tile, Ball ball)
        {
            BounceOff(tile, ball);
            if(NeedReduceHP(tile, ball))
            {
                ReduceHP(tile, ball);
            }
            if(NeedDestroy(tile, ball))
            {
                Destroy(tile, ball);
            }
        }

    }
}
