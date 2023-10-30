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
            PowerUpDirector pd = new PowerUpDirector();
            switch (type)
            {
                case "shrink":
                    return pd.ConstructShrink(x,y);
                case "fastBall":
                    return pd.ConstructFastBall(x,y);
                default:
                    break;
            }
            throw new ArgumentException(string.Format("{0} is not a valid powerup type", type));
        }

    }
}
