namespace Arkanoid.Data.PowerUps
{
    public class PositivePowerUpFactory: PowerUpFactory
    {
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
                    return new Expand(x, y);
                case "piercingBall":
                    return new PiercingBall(x, y);
                default:
                    break;
            }
            return null;
        }
    }
}
