using System.Drawing;

namespace Arkanoid.Data.PowerUps
{
    public abstract class PowerUp
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public string Color { get; protected set; }
        public int Size { get; protected set; }

        public PowerUp(int x, int y, string color, int size)
        {
            X = x;
            Y = y;
            Color = color;
            Size = size;
        }

        public void SetX(int value)
        {
            X = value;
        }

        public void SetY(int value)
        {
            Y = value;
        }

        public void SetColor(string value)
        {
            Color = value;
        }
        public void SetSize(int value)
        {
            Size = value;
        }
    }


}
