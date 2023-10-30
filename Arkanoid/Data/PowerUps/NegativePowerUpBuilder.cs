using Arkanoid.Data.PowerUps.Arkanoid.Data.PowerUps;

namespace Arkanoid.Data.PowerUps
{
    public enum NegativePUType { FastBall, Shrink}
    public class NegativePowerUpBuilder : IPowerUpBuilder
    {
        private PowerUp powerUp = new ConcreteNegativePowerUp(0, 0, "red", 0);
        public NegativePowerUpBuilder() { }
        public NegativePowerUpBuilder(NegativePUType type)
        {
            switch (type)
            {
                case NegativePUType.FastBall:
                    powerUp = new FastBall(0, 0);
                    break;
                case NegativePUType.Shrink:
                    powerUp = new Shrink(0, 0);
                    break;
                default:
                    break;
            }
        }
        public IPowerUpBuilder SetPosition(int x, int y)
        {
            powerUp.SetX(x);
            powerUp.SetY(y);
            return this;
        }

        public IPowerUpBuilder SetColor(string color)
        {
            powerUp.SetColor(color);
            return this;
        }

        public IPowerUpBuilder SetSize(int size)
        {
            powerUp.SetSize(size);
            return this;
        }

        public PowerUp Build()
        {
            return powerUp;
        }
    }

}
