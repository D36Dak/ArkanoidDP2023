using Arkanoid.Data.PowerUps.Arkanoid.Data.PowerUps;

namespace Arkanoid.Data.PowerUps
{
    public enum PositivePUType { Expand, PiercingBall}
    public class PositivePowerUpBuilder : IPowerUpBuilder
    {
        private PowerUp powerUp = new ConcretePositivePowerUp(0, 0, "green", 0);
        public PositivePowerUpBuilder()
        {

        }
        public PositivePowerUpBuilder(PositivePUType type)
        {
            switch (type)
            {
                case PositivePUType.Expand:
                    powerUp = new Expand(0,0);
                    break;
                case PositivePUType.PiercingBall:
                    powerUp = new PiercingBall(0,0);
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
