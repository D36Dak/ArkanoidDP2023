using System.Drawing;

namespace Arkanoid.Data.PowerUps
{
    public abstract class PowerUp
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public string? Color {  get; protected set; }
        public int Size { get; protected set; }
        public PowerUp(int X, int Y, string color, int size)
        {
            this.X = X;
            this.Y = Y;
            this.Color = color;
            Size = size;
        }
    }
}
