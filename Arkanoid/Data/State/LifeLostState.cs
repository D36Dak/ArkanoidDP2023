namespace Arkanoid.Data.State
{
    public class LifeLostState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();
            ge.LoseLife();
            _= ge.ResetBallPosition();
            if (ge.HP == 0)
            {
                ge.SetState(new LostState());
            }
            else
            {
                ge.SetState(new PausedState());
            }
        }

        public string GetMessage()
        {
            return string.Empty;
        }
    }
}
