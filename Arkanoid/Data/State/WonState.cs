namespace Arkanoid.Data.State
{
    public class WonState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();
            _ = ge.StopTimer();
        }

        public string GetMessage()
        {
            return "You Win!";
        }
    }
}
