using System.Drawing;

namespace Arkanoid.Data.PowerUps
{
    public abstract class PowerUp
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public string? Color { get; protected set; }
        public int Size { get; protected set; }
        public PowerUpDirector director;
        public IPowerUpBuilder positiveBuilder;
        public IPowerUpBuilder negativeBuilder;
        public PowerUp positivePowerUp;
        public PowerUp negativePowerUp;

        public PowerUp(int X, int Y, string color, int size)
        {
            this.X = X;
            this.Y = Y;
            this.Color = color;
            Size = size;

            director = new PowerUpDirector();
            positiveBuilder = new PositivePowerUpBuilder();
            negativeBuilder = new NegativePowerUpBuilder();

            positivePowerUp = director.Construct(positiveBuilder, 10, 20, "green", 30);

            
            negativePowerUp = director.Construct(negativeBuilder, 40, 50, "red", 25);
        }
    }

}
