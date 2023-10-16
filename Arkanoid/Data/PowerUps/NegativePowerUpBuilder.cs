using Arkanoid.Data.PowerUps.Arkanoid.Data.PowerUps;

namespace Arkanoid.Data.PowerUps
{
    public class NegativePowerUpBuilder : IPowerUpBuilder
    {
        private int x, y, size;
        private string color;

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public PowerUp Build()
        {
            return new ConcreteNegativePowerUp(x, y);
        }
    }
}
