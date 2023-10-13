using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Timers;
using Arkanoid.Data.Tiles;
using Arkanoid.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data
{

    public class GameEngine : IAsyncDisposable
    {
        private static GameEngine? Instance = null;
        private HubConnection? hubConnection;
        private GameWindow Window = new GameWindow();
        public Ball Ball { get; private set; }
        public Paddle P1;
        public Paddle P2;
        private System.Timers.Timer? timer;
        private static object ThreadLock = new object();
        public List<Tile> Tiles = new();
        public Paddle? Player { get; set; } = null;

        private GameEngine()
        {
            Ball = new Ball(Window);
            P1 = new Paddle(200, "", Side.LEFT, Ball);
            P2 = new Paddle(840, "", Side.RIGHT, Ball);
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

        public async Task DestroyTile(Tile tile)
        {
            if(hubConnection != null && Player != null)
                await hubConnection.SendAsync("RemoveTile", tile.Position.X, tile.Position.Y, Player.id);
        }

        public async Task InvertBallDirection(BounceDir dir)
        {
            if (hubConnection != null && Player != null)
            {
                await hubConnection.SendAsync("InvertBall", dir, Player.id);
            }
        }

        public void ConnectToHub(HubConnection hubConnection)
        {
            if (this.hubConnection is null)
            {
                this.hubConnection = hubConnection;

                hubConnection.On<float, float>("ReceiveRemoveTile", (x, y) =>
                {
                    // Maybe have an identifier for each tile? Probably would have syncing problems.
                    var tileToRemove = Tiles.Find(w => w.Position.X == x && w.Position.Y == y);
                    if (tileToRemove != null)
                    {
                        // unatach from ball so that tile stops calculating collisions.
                        Ball.UnAttach(tileToRemove);
                        // remove from rendering list
                        Tiles.Remove(tileToRemove);
                    }
                });

                hubConnection.On<BounceDir>("ReceiveInvertBall", (dir) =>
                {
                    if (dir == BounceDir.Vertical)
                        Ball.InvertY();
                    else Ball.InvertX();
                });
            }
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
            Ball.SetPosition(0, 0);
            // top = 0; left = 0;
            Send();
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
    }
}