using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public abstract class Tile : IObserver
    {
        public string Color { get; private set; }
        // top right corner
        public Vector2 Position { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        protected Ball ball { get; private set; }
        public Tile(Ball ball, string color, Vector2 position, int width = 100, int height = 50)
        {
            Color = color;
            Position = position;
            this.ball = ball;
            ball.Attach(this);
            Width = width;
            Height = height;
        }

        ~Tile()
        {
            ball.UnAttach(this);
        }

        public abstract void OnHit();

        public void Update()
        {
            if(ball.GetMiddleX() > Position.X && ball.GetMiddleX() < Position.X + Width
                && ball.GetMiddleY() > Position.Y && ball.GetMiddleY() < Position.Y + Height)
            {
                // somehow determine which wall was hit
                // bounce off
                // or do i all of that in OnHit. That probably would be better
                OnHit();
            }
        }
    }
}
