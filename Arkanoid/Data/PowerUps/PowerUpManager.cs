using Arkanoid.Data.Tiles;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Arkanoid.Data.PowerUps
{
    public enum PUFTypes { Positive, Negative }
    public static class PowerUpManager
    {
        public static PowerUpFactory getPUF(PUFTypes type)
        {
            switch (type)
            {
                case PUFTypes.Positive:
                    return new PositivePowerUpFactory();
                case PUFTypes.Negative:
                    return new NegativePowerUpFactory();
                default:
                    throw new ArgumentException("No such factory");
            }
        }
    }
}
