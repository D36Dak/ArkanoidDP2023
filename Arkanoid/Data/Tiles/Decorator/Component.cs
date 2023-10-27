using System.Numerics;

namespace Arkanoid.Data.Tiles.Decorator
{
    public abstract class Component : IObserver, IPrototype<Component>
    {
        private bool isInside = false;
        public string Color { get; set; }
        public Decorator? Decorator { get; set; }
        // top right corner
        public Vector2 Position { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int HP { get; set; }
        public Ball Ball { get; private set; }
        public Vector2 Middle
        {
            get
            {
                return new Vector2(Position.X + Width / 2, Position.Y + Height / 2);
            }
        }

        public Component(string color, Vector2 position, Ball ball, Decorator? decorator, int hp = 1, int width = 100, int height = 50)
        {
            Color = color;
            Position = position;
            Decorator = decorator;
            Width = width;
            Height = height;
            Ball = ball;
            HP = hp;
            ball.Attach(this);
        }

        ~Component()
        {
            Ball.UnAttach(this);
        }

        public abstract void OnHit(Component tile, Ball ball);

        public abstract Component Clone();
        //public abstract Component DeepCopy();

    public void Update()
        {
            if (Ball.GetMiddleX() > Position.X && Ball.GetMiddleX() < Position.X + Width
                && Ball.GetMiddleY() > Position.Y && Ball.GetMiddleY() < Position.Y + Height)
            {
                // check if the ball is inside of the tile. Prevent multiple hits.
                if (isInside) return;
                isInside = true;
                // somehow determine which wall was hit

                // bounce off
                // or do i all of that in OnHit. That probably would be better
                if (Decorator == null) OnHit(this, Ball);
                else Decorator.OnHit(this, Ball);
            }
            else
                isInside = false;
        }
    }
}
