using System.Drawing;

namespace Arkanoid.Data.PowerUps
{
    public class PowerUpDirector
    {
        public PowerUp Construct(IPowerUpBuilder builder, int x, int y, string color, int size)
        {
            return builder.SetPosition(x, y)
            .SetColor(color)
            .SetSize(size)
            .Build();
        }
        public PowerUp ConstructShrink(int x, int y)
        {
            var builder = new NegativePowerUpBuilder(NegativePUType.Shrink);
            return builder.SetPosition(x, y)
            .SetColor("red")
            .SetSize(30)
            .Build();
        }
        public PowerUp ConstructFastBall(int x, int y)
        {
            var builder = new NegativePowerUpBuilder(NegativePUType.FastBall);
            return builder.SetPosition(x, y)
            .SetColor("red")
            .SetSize(30)
            .Build();
        }
        public PowerUp ConstructExpand(int x, int y)
        {
            var builder = new PositivePowerUpBuilder(PositivePUType.Expand);
            return builder.SetPosition(x, y)
            .SetColor("green")
            .SetSize(20)
            .Build();
        }
        public PowerUp ConstructPiercing(int x, int y)
        {
            var builder = new PositivePowerUpBuilder(PositivePUType.PiercingBall);
            return builder.SetPosition(x, y)
            .SetColor("green")
            .SetSize(20)
            .Build();
        }
    }

}
