namespace Arkanoid.Data.PowerUps
{
    public class PositivePowerUpFactory : PowerUpFactory
    {
        PowerUpDirector director = new PowerUpDirector();
        IPowerUpBuilder positiveBuilder = new PositivePowerUpBuilder();

        public PositivePowerUpFactory()
        {
            base.PowerUpTypes.Add("expand");
            base.PowerUpTypes.Add("piercingBall");
        }

        public override PowerUp CreatePowerUp(string type, int x, int y)
        {
            PowerUpDirector pd = new PowerUpDirector();
            switch (type)
            {
                case "expand":
                    return pd.ConstructExpand(x, y);
                case "piercingBall":
                    return pd.ConstructPiercing(x, y);
                default:
                    break;
            }
            throw new ArgumentException(string.Format("{0} is not a valid powerup type", type));
        }
    }
}
