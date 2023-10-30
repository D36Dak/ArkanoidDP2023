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
            switch (type)
            {
                case "expand":
                    return director.Construct(positiveBuilder, x, y, "green", 30);
                case "piercingBall":
                    return director.Construct(positiveBuilder, x, y, "green", 30);
                default:
                    break;
            }
            throw new ArgumentException(string.Format("{0} is not a valid powerup type", type));
        }
    }
}
