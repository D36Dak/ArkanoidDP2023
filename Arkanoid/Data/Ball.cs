using Arkanoid.Data.Adapter;
using Arkanoid.Data.Strategy;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace Arkanoid.Data
{
    public class Ball : ISubject, IMovable
    {
        private int X;
        private int Y;
        private int SpeedX;
        public int SpeedY { get; private set; }
        private int BallSize = 20;
        private GameWindow GameWindow;
        public string? Pid { get; set; } = null;
        public BallMoveAlgorithm MoveAlgorithm { private get; set; }

        public List<IObserver> Observers = new();

        public Ball(GameWindow gameWindow)
        {
            MoveAlgorithm = new RegularBallStrategy();
            X = 0;
            Y = 0;
            GameWindow = gameWindow;
            SpeedX = 0;
            SpeedY = 0;
        }
        public Ball(int x, int y, GameWindow gameWindow)
        {
            MoveAlgorithm = new RegularBallStrategy();
            X = x;
            Y = y;
            GameWindow = gameWindow;
            SpeedX = 0;
            SpeedY = 0;
        }
        public Ball(GameWindow gameWindow, BallMoveAlgorithm moveAlgorithm)
        {
            MoveAlgorithm = moveAlgorithm;
            X = 0;
            Y = 0;
            GameWindow = gameWindow;
            SpeedX = 0;
            SpeedY = 0;
        }
        
        /// <summary>
        /// Sets ball speed. Recommended to use values adding up to 6.
        /// (1,5) (3,3) (-1,5) (-3,-3) etc.
        /// </summary>
        /// <param name="vx">Horizontal speed</param>
        /// <param name="vy">Vertical speed</param>
        public void SetSpeed(int vx, int vy)
        {
            this.SpeedX = vx;
            this.SpeedY = vy;
        }
        public void InvertX()
        {
            this.SpeedX *= -1;
        }
        public void InvertY()
        {
            this.SpeedY *= -1;
        }
        public int GetNextX()
        {
            return this.X + this.SpeedX;
        }
        public int GetNextY()
        {
            return this.Y + this.SpeedY;
        }

        public void Move()
        {
            MoveAlgorithm.Move(this);
        }

        //todo - fix avoiding walls at distance,calculate distance to wall and subtract from final position
        public void Update()
        {
            Move();
        }
        public int GetX()
        {
            return this.X;
        }
        public int GetY()
        {
            return this.Y;
        }
        public void SetPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
            //Console.WriteLine(String.Format("Position after set {0} : {1}", X, Y));
        }
        public int GetSize()
        {
            return this.BallSize;
        }
        public int GetMiddleX()
        {
            return this.BallSize / 2 + X;
        }
        public int GetMiddleY()
        {
            return this.BallSize/2 + Y;
        }
        public int GetWindowHeight()
        {
            return this.GameWindow.GetHeight();
        }
        public int GetWindowWidth()
        {
            return this.GameWindow.GetWidth();
        }

        public void Attach(IObserver observer)
        {
            if (Observers.Contains(observer)) return;
            Observers.Add(observer);
        }

        public void UnAttach(IObserver observer)
        {
            Observers.Remove(observer);
        }
        public void NotifyAll()
        {
            // had to convert to list because getting operation not permitted..
            foreach(var observer in Observers.ToList())
            {
                observer.Update();
            }
        }
    }
}
