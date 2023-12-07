namespace Arkanoid.Data.State
{
    public class LifeLostState : IGameState
    {
        public void Action()
        {
            GameEngine ge = GameEngine.GetInstance();

            // Restore the X position of Paddle1 to the default value
            Memento defaultStates1 = ge.GetPaddle1DefaultX();
            ge.P1.SetMemento(defaultStates1);

            // Restore the X position of Paddle2 to the default value
            Memento defaultStates2 = ge.GetPaddle2DefaultX();
            ge.P2.SetMemento(defaultStates2);

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
