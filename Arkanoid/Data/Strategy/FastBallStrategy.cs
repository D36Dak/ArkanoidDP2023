namespace Arkanoid.Data.Strategy
{
    public class FastBallStrategy : BallMoveAlgorithm
    {
        public override void Move(Ball ball)
        {
            for (int i = 0; i < 2; i++)
            {
                int x1 = ball.GetNextX();
                int y1 = ball.GetNextY();
                if (x1 > ball.GetWindowWidth() - ball.GetSize() || x1 < 0)
                {
                    ball.InvertX();
                    x1 = ball.GetNextX();
                }
                if (y1 > ball.GetWindowHeight() - ball.GetSize() || y1 < 0)
                {
                    ball.InvertY();
                    y1 = ball.GetNextY();
                }
                ball.SetPosition(x1, y1);
            }
            ball.NotifyAll();
        }
    }
}
