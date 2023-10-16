namespace Arkanoid.Data.Strategy
{
    public class TeleportSideStrategy : BallMoveAlgorithm
    {
        public override void Move(Ball ball)
        {
            int x1 = ball.GetNextX();
            int y1 = ball.GetNextY();
            if (x1 > ball.GetWindowWidth() - ball.GetSize())
            {
                x1 = 0;
            } else if (x1 < 0)
            {
                x1 = ball.GetWindowWidth() - ball.GetSize();
            }
            if (y1 > ball.GetWindowHeight() - ball.GetSize() || y1 < 0)
            {
                ball.InvertY();
                y1 = ball.GetNextY();
            }
            ball.SetPosition(x1, y1);
            ball.NotifyAll();
        }
    }
}
