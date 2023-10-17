﻿using Arkanoid.Data.PowerUps.Arkanoid.Data.PowerUps;

namespace Arkanoid.Data.PowerUps
{
    public class PositivePowerUpBuilder : IPowerUpBuilder
    {
        private PowerUp powerUp = new ConcretePositivePowerUp(0, 0, "green", 0);

        public void SetPosition(int x, int y)
        {
            powerUp.SetX(x);
            powerUp.SetY(y);
        }

        public void SetColor(string color)
        {
            powerUp.SetColor(color);
        }

        public void SetSize(int size)
        {
            powerUp.SetSize(size);
        }

        public PowerUp Build()
        {
            return powerUp;
        }
    }

}
