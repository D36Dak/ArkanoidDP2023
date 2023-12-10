using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Timers;
using Arkanoid.Data.Adapter;
using Arkanoid.Data.PowerUps;
using Arkanoid.Data.State;
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
        private PaddleCaretaker paddle1Caretaker = new PaddleCaretaker(); // Create PaddleCaretaker
        private PaddleCaretaker paddle2Caretaker = new PaddleCaretaker(); // Create PaddleCaretaker
        public List<int> Paddle1DefaultStates { get; private set; } = new List<int>(); // List to store default X values for Paddle 1
        public List<int> Paddle2DefaultStates { get; private set; } = new List<int>(); // List to store default X values for Paddle 2
        public Ball Ball { get; private set; }
        public Paddle P1;
        public Paddle P2;
        public TileManager? tm;
        private System.Timers.Timer? timer;
        private TileFactory tf = new TileFactory();
        private static object ThreadLock = new();
        public MovableManager movableManager = new();
        public List<PowerUp> visiblePowerUps = new List<PowerUp>();
        public int HP { get; private set; }
        public IGameState gameState { get; private set; }
        private GameEngine()
        {
            
            Ball = new Ball(Window);
            movableManager.AddMovable(Ball);
            P1 = new Paddle(200, "", Side.LEFT, Ball);
            P2 = new Paddle(840, "", Side.RIGHT, Ball);
            paddle1Caretaker.Memento = CreatePaddle1DefaultX();
            paddle2Caretaker.Memento = CreatePaddle2DefaultX();
            ResetBallPosition();
            SetSpeed(3, 3);
            SetupTimer();
            HP = 3;
            gameState = new PausedState();
        }

        public List<Component> GetTilesInRadius(Component tile, int radius)
        {
            var tilesInRadius = new List<Component>();
            if(tm == null) return tilesInRadius;
            foreach(var t in tm.tiles)
            {
                var dist = Vector2.Distance(t.Position, tile.Position);
                if(dist <= radius) tilesInRadius.Add(t);
            }
            return tilesInRadius;
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

        public void ConnectToHub(NavigationManager navigationManager)
        {
            if (hubConnection is null)
            {
                hubConnection = new HubConnectionBuilder()
                    .WithUrl(navigationManager.ToAbsoluteUri("/gamehub"))
                    .Build();
                hubConnection.StartAsync();
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
            MovableIterator iterator = movableManager.CreateIterator();
            for (var element = iterator.First(); !iterator.IsDone(); element = iterator.Next())
            {
                ((IMovable)element).Move();
            }
            //foreach(var movable in movableManager.GetMovables())
            //{
            //    movable.Move();
            //}
            
            //foreach (var movable in movables)
            //{
            //    movable.Move();
            //}
            CheckHPLoss();
            //Ball.Update();
            //Console.WriteLine(String.Format("Ball pos: {0} : {1}", Ball.GetX(), Ball.GetY()));
            Send();
        }

        private void CheckHPLoss()
        {
            if (this.Ball.GetY()>GetWindowHeight()-40)
            {
                SetState(new LifeLostState());
            }
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
                        var pos = new Vector2(offset.X, offset.Y + i * (height + gap.Y));
                        Component tile = tf.CreateTile(TileType.Regular, pos);
                        if (i == 0)
                        {
                            tile = new DropPowerUp(tile);
                        }

                        for (var j = 1; j < 10; j++)
                        {
                            Vector2 newPos = new Vector2(offset.X + j * (width + gap.X), offset.Y + i * (height + gap.Y));
                            if (i == 2 && j == 4)
                            {
                                Component explosive = tf.CreateTile(TileType.Explosive, newPos);
                                tm.tiles.Add(explosive);
                                continue;
                            }
                            // Shallow copy
                            Component clonedTile = tile.Clone();
                            clonedTile.Position = new Vector2(offset.X + j * (width + gap.X), offset.Y + i * (height + gap.Y));
                            tm.tiles.Add(clonedTile);

                            //Deep copy
                            //Component deepClonedTile = tile.DeepCopy();
                            //deepClonedTile.Position = new Vector2(offset.X + j * (width + gap.X), offset.Y + i * (height + gap.Y));
                            //tm.tiles.Add(deepClonedTile);

                            
                        }
                        tm.tiles.Add(tile);
                    }
                    Ball.SetPosition(P1.GetX() + P1.GetWidth() / 2, P1.GetY() - Ball.GetSize());
                    SetBallMovementStrategy(new RegularBallStrategy());
                    visiblePowerUps = new List<PowerUp>();
                    //movables = new List<IMovable>();
                    //movables.Add(Ball);
                    movableManager = new MovableManager();
                    movableManager.AddMovable(Ball);
                    this.HP = 3;
                    break;
                default: break;
            }
            SetState(new PausedState());
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
        public void AddVisiblePowerUp(PowerUp powerUp)
        {
            this.visiblePowerUps.Add(powerUp);
            MoveAdapter adapter = new MoveAdapter(powerUp);
            this.movableManager.AddMovable(adapter);
        }
        public void RemovePowerUp(PowerUp powerUp)
        {
            this.visiblePowerUps.Remove(powerUp);
            var toRemove = movableManager.GetMovables().OfType<MoveAdapter>().Where(m => m.Adaptee.Equals(powerUp)).ToList();
            foreach (var removable in toRemove)
            {
                movableManager.RemoveMovable(removable);
            }
        }
        public void LoseLife()
        {
            this.HP--;
            HP = Math.Max(0, this.HP);
        }
        public void SetState(IGameState state)
        {
            if (HP == 0 && state is RunningState)
            {
                return;
            }
            this.gameState = state;
            this.gameState.Action();
        }

        public Memento CreatePaddle1DefaultX()
        {
            List<int> defaultXState = new List<int> { 200 };
            return new Memento(defaultXState); // Store this initial state as the default for Paddle 1
        }

        public Memento CreatePaddle2DefaultX()
        {
            List<int> defaultXState = new List<int> { 840 };
            return new Memento(defaultXState); // Store this initial state as the default for Paddle 2
        }

        public Memento GetPaddle1DefaultX()
        {
            return paddle1Caretaker.Memento;
        }

        public Memento GetPaddle2DefaultX()
        {
            return paddle2Caretaker.Memento;
        }
    }
}