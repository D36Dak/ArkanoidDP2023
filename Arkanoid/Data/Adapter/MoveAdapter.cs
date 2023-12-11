using Arkanoid.Data.PowerUps;
using System.Numerics;

namespace Arkanoid.Data.Adapter
{
    public class MoveAdapter : IMovable
    {
        public PowerUp Adaptee { get; private set; }
        public Vector2 Position { get;private set; }

        public MoveAdapter(PowerUp Adaptee)
        {
            this.Adaptee = Adaptee;
        }

        public void Move()
        {
            Adaptee.SpecificMove();
        }
        public int GetPositionY()
        {
            return (int)Position.Y;
        }
    }
}
