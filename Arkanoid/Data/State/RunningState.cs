namespace Arkanoid.Data.State
{
    public class RunningState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();
            _ = ge.StartTimer();
        }

        public string GetMessage()
        {
            return "Game is running";
        }
    }
}
