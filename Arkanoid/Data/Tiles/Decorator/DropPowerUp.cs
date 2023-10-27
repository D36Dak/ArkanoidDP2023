using System.Numerics;

namespace Arkanoid.Data.Tiles.Decorator
{
    public class DropPowerUp : Decorator
    {
        public DropPowerUp(Component component) : base(component)
        {
        }

        public override void OnHit(Component tile, Ball ball)
        {
            // instantiate power up and add it to dropping list or something...
        }

        public override Component Clone()
        {
            //return new DropPowerUp(Component);
            return (DropPowerUp)this.MemberwiseClone();
        }
    }
}
