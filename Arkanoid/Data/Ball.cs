﻿using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace Arkanoid.Data
{
    public class Ball
    {
        private int X;
        private int Y;
        private int SpeedX;
        private int SpeedY;
        private int BallSize = 20;
        private GameWindow GameWindow;

        public Ball(GameWindow gameWindow)
        {
            X = 0;
            Y = 0;
            GameWindow = gameWindow;
            SpeedX = 0;
            SpeedY = 0;
        }
        public Ball(int x, int y, GameWindow gameWindow)
        {
            X = x;
            Y = y;
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
        //todo - fix avoiding walls at distance,calculate distance to wall and subtract from final position
        public void Update()
        {
            //Console.WriteLine("Current speed is {0} : {1}", SpeedX, SpeedY);
            int x1 = GetNextX();
            int y1 = GetNextY();
            if (x1 > GameWindow.GetWidth() -BallSize || x1 < 0)
            {
                InvertX();
                x1 = GetNextX();
            }
            if (y1 > GameWindow.GetHeight() -BallSize || y1 < 0)
            {
                InvertY();
                y1 = GetNextY();
            }
            SetPosition(x1, y1);
            //Console.WriteLine("Next position should be {0} : {1}",x1, y1);
            //Console.WriteLine(String.Format("{0} : {1}",SpeedX,SpeedY));
            //IncrementLeft();
            //IncrementTop();
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
    }
}
