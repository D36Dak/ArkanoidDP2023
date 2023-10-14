using Arkanoid.Data.Tiles.Decorator;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public abstract class Tile : Component, IObserver
    {
        public string Color { get; set; }
        public TileManager TileManager { get; private set; }
        public Decorator.Decorator? Decorator { get; set; }
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
        public Tile(Ball ball, string color, Vector2 position, TileManager tileManager, Decorator.Decorator? decorator = null, int width = 100, int height = 50)
        {
            Color = color;
            Position = position;
            this.ball = ball;
            ball.Attach(this);
            Width = width;
            Height = height;
            TileManager = tileManager;
            Decorator = decorator;
        }

        ~Tile()
        {
            ball.UnAttach(this);
        }

        #region extract to some other static class
        // should be extracted into a static class
        
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
                if(Decorator == null) OnHit(this, ball);
                else Decorator.OnHit(this, ball);
            }
            else
                isInside = false;
        }
    }
}
