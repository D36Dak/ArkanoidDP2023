namespace Arkanoid.Data.Command
{
    public class RightCommand : ICommand
    {
        public Paddle Paddle;
        public int previous;

        public RightCommand(Paddle paddle)
        {
            Paddle = paddle;
        }

        public void Execute()
        {
            previous = Paddle.GetX();
            Paddle.Move("Right");
        }

        public void Undo()
        {
            Paddle.SetX(previous);
        }
    }
}
