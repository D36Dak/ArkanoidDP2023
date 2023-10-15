namespace Arkanoid.Data.PowerUps
{
    public class NegativePowerUpFactory : PowerUpFactory
    {
        public NegativePowerUpFactory()
        {
            base.PowerUpTypes.Add("shrink");
            base.PowerUpTypes.Add("fastBall");
        }

        public override PowerUp CreatePowerUp(string type, int x, int y)
        {
            switch (type)
            {
                case "shrink":
                    return new Shrink(x, y);
                case "fastBall":
                    return new FastBall(x, y);
                default:
                    break;
            }
            return null;
        }

    }
}
