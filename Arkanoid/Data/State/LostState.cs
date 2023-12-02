namespace Arkanoid.Data.State
{
    public class LostState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();
            _ = ge.StopTimer();
        }

        public string GetMessage()
        {
            return "Game Over!";
        }
    }
}
