using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Timers;
using Arkanoid.Data.Strategy;
using Arkanoid.Data.Tiles;
using Arkanoid.Data.Tiles.Decorator;
using Arkanoid.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data
{

    public class GameEngine : IAsyncDisposable
    {
        private static GameEngine? Instance = null;
        private HubConnection? hubConnection;
        private GameWindow Window = new();
        public Ball Ball { get; private set; }
        public Paddle P1;
        public Paddle P2;
        public TileManager? tm;
        private System.Timers.Timer? timer;
        private TileFactory tf = new TileFactory();
        private static object ThreadLock = new();
        private GameEngine()
        {
            Ball = new Ball(Window);
            P1 = new Paddle(200, "", Side.LEFT, Ball);
            P2 = new Paddle(840, "", Side.RIGHT, Ball);
            ResetBallPosition();
            SetSpeed(3, 3);
            SetupTimer();
        }
        public static GameEngine GetInstance()
        {
            lock (ThreadLock)
            {
                Instance ??= new GameEngine();
                return Instance;
            }
        }

        public async Task InvertBallDirection(BounceDir dir)
        {
            if (dir == BounceDir.Vertical)
                Ball.InvertY();
            else Ball.InvertX();
        }

        public void ConnectToHub(HubConnection hubConnection)
        {
            if (this.hubConnection is null)
            {
                this.hubConnection = hubConnection;

                hubConnection.On<BounceDir>("ReceiveInvertBall", (dir) =>
                {
                    if (dir == BounceDir.Vertical)
                        Ball.InvertY();
                    else Ball.InvertX();
                });
            }
        }

        public void RemoveTileFromCollisions(Component tile)
        {
            Ball.UnAttach(tile);
        }

        private void SetupTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 16;
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = false;
        }
        private void TimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            Ball.Update();
            //Console.WriteLine(String.Format("Ball pos: {0} : {1}", Ball.GetX(), Ball.GetY()));
            Send();
        }
        private async Task Send()
        {
            if (hubConnection is not null)
            {
                await hubConnection.SendAsync("SendPosition", Ball.GetX(), Ball.GetY(), "ball");
            }
        }
        public async Task StartTimer()
        {
            if (timer is not null)
            {
                timer.Enabled = true;
            }
        }
        public async Task StopTimer()
        {
            if (timer is not null)
            {
                timer.Enabled = false;
            }
        }
        public async Task SetSpeed(int speedX, int speedY)
        {
            Ball.SetSpeed(speedX, speedY);
        }
        public async Task ResetBallPosition()
        {
            Ball.SetPosition(P1.GetX() + P1.GetWidth() / 2, P1.GetY() - Ball.GetSize());
            // top = 0; left = 0;
            _ = Send();
        }
        public void LoadLevel(int nr)
        {
            _ = StopTimer();
            tm ??= new TileManager();
            while (tm.tiles.Count>0)
            {
                _ = tm.DestroyTile(tm.tiles[0]);
            }
            switch (nr)
            {
                case 1:
                    Vector2 offset = new Vector2(40, 20);
                    Vector2 gap = new Vector2(20, 20);
                    int width = 100;
                    int height = 50;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 10; j++)
                        {
                            var pos = new Vector2(offset.X + j * (width + gap.X), offset.Y + i * (height + gap.Y));
                            Component tile = tf.CreateTile(TileType.Regular, pos);
                            tm.tiles.Add(tile);
                        }
                    }
                    Ball.SetPosition(P1.GetX() + P1.GetWidth() / 2, P1.GetY() - Ball.GetSize());
                    break;
                default: break;
            }
            _ = Send();
        }
        public async Task SetBallPosition(int x, int y)
        {
            Ball.SetPosition(x, y);
        }
        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
        public int GetWindowHeight()
        {
            return this.Window.GetHeight();
        }
        public int GetWindowWidth()
        {
            //Console.WriteLine(Window.GetWidth());
            return this.Window.GetWidth();
        }
        public int GetBallX()
        {
            return Ball.GetX();
        }
        public int GetBallY()
        {
            return Ball.GetY();
        }
        public int GetBallSize()
        {
            return Ball.GetSize();
        }
        public void SetBallMovementStrategy(BallMoveAlgorithm strategy)
        {
            this.Ball.MoveAlgorithm = strategy;
        }
    }
}