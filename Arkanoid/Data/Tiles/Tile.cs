using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public abstract class Tile : IObserver
    {
        public string Color { get; private set; }
        // top right corner
        public Vector2 Position { get; private set; }
        public Vector2 Middle { 
            get
            {
                return new Vector2(Position.X + Width/2, Position.Y + Height/2);
            } 
        }
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

        #region extract to some other static class
        // should be extracted into a static class
        private static Vector3 GetLineCoeffs(Vector2 p1, Vector2 p2)
        {
            //Ax + Bx + C = 0
            float a = p1.Y - p2.Y;
            float b = p2.X - p1.X;
            float c = p1.X * p2.Y - p2.X * p1.Y;
            return new Vector3(a, b, c);
        }

        private static float LineY(Vector3 coeffs, float x)
        {
            return -(coeffs.X * x + coeffs.Z) / coeffs.Y;
        }

        private static float LineX(Vector3 coeffs, float y)
        {
            return -(coeffs.Y * y + coeffs.Z) / coeffs.X;
        }

        protected enum BounceDir { Vertical, Horizontal }
        protected BounceDir GetBounceOffDirection()
        {
            Vector3 Line1Coeffs = GetLineCoeffs(Position, new Vector2(Position.X + Width, Position.Y + Height));
            Vector3 Line2Coeffs = GetLineCoeffs(new Vector2(Position.X, Position.Y + Height), new Vector2(Position.X + Width, Position.Y));
            Vector2 Line1 = new Vector2(LineX(Line1Coeffs, ball.GetY()), LineY(Line1Coeffs, ball.GetX()));
            Vector2 Line2 = new Vector2(LineX(Line2Coeffs, ball.GetY()), LineY(Line2Coeffs, ball.GetX()));

            // hit is from the top or the bottom
            if(Line1.Y > Middle.Y && Line2.Y > Middle.Y || Line1.Y < Middle.Y && Line2.Y < Middle.Y)
            {
                return BounceDir.Vertical;
            }
            // hit can only be horizontal now now
            else
            {
                return BounceDir.Horizontal;
            }
        }
        #endregion
        private bool isInside = false;
        public void Update()
        {
            if(ball.GetMiddleX() > Position.X && ball.GetMiddleX() < Position.X + Width
                && ball.GetMiddleY() > Position.Y && ball.GetMiddleY() < Position.Y + Height)
            {
                // to check if the ball is inside of the tile. Prevent multiple hits.
                if (isInside) return;
                isInside = true;
                // somehow determine which wall was hit

                // bounce off
                // or do i all of that in OnHit. That probably would be better
                OnHit();
            }else
                isInside = false;
        }
    }
}
