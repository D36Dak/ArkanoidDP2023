﻿namespace Arkanoid.Data
{
    public class Paddle: IObserver
    {
        private int X;
        private int Width = 200;
        private int Height = 20;
        private const int Y = 720 - 60;
        public string id { get; set; }
        public Side side { get; set; }
        public string color = "blue";
        protected Ball Ball { get; set; }

        public Paddle(int x, string id, Side side, Ball ball)
        {
            X = x;
            this.id = id;
            this.side = side;
            Ball = ball;
            ball.Attach(this);
        }

        /// <summary>
        /// Destructor for unataching this observer from subject
        /// </summary>
        ~Paddle()
        {
            Ball.UnAttach(this);
        }

        public int GetWidth()
        {
            return Width;
        }
        public int GetHeight()
        {
            return Height;
        }
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public void SetX(int x)
        {
            X = x;
        }
        public void MoveLeft()
        {
            X += 5;
        }
        public void MoveRight()
        {
            X -= 5;
        }

        public void Update()
        {
            if (Ball != null)
            {
                if(Ball.GetY()+Ball.GetSize() > Y && Ball.SpeedY > 0 && Ball.GetMiddleX() < X + Width && Ball.GetMiddleX() > X)
                {                    
                    Ball.InvertY();
                }
            }
        }
    }
}
