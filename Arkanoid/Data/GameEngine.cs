using System.Reflection.Metadata;
using System.Timers;
using Arkanoid.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Arkanoid.Data
{
    
    public class GameEngine:IAsyncDisposable
    {
        private readonly NavigationManager Navigation;
        private HubConnection? hubConnection;
        private GameWindow Window = new GameWindow();
        private Ball Ball;
        public Paddle P1;
        public Paddle P2;
        private System.Timers.Timer? timer;

        public GameEngine(NavigationManager navManager)
        {
            Navigation = navManager;
            hubConnection = new HubConnectionBuilder()
                .WithUrl(Navigation.ToAbsoluteUri("/gamehub"))
                .Build();
            hubConnection.StartAsync();
            Ball = new Ball(Window);
            P1 = new Paddle(200, "", Side.LEFT, Ball);
            P2 = new Paddle(200, "", Side.RIGHT, Ball);
            SetupTimer();
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
