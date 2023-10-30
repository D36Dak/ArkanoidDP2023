namespace Arkanoid.Data.PowerUps
{
    public class NegativePowerUpFactory : PowerUpFactory
    {
        PowerUpDirector director = new PowerUpDirector();
        IPowerUpBuilder negativeBuilder = new NegativePowerUpBuilder();

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
                    return director.Construct(negativeBuilder, x, y, "red", 25);
                case "fastBall":
                    return director.Construct(negativeBuilder, x, y, "red", 25);
                default:
                    break;
            }
            return null;
        }
    }
}
