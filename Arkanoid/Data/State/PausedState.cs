namespace Arkanoid.Data.State
{
    public class PausedState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();
            ge.StopTimer();
        }

        public string GetMessage()
        {
            return "Paused...";
        }
    }
}
