namespace Arkanoid.Data.PowerUps
{
    public abstract class PowerUpFactory
    {
        public List<string> PowerUpTypes = new List<string>();
        public abstract PowerUp CreatePowerUp(string type, int x, int y);
    }
}
