namespace Arkanoid.Data.Command
{
    public class LeftCommand : ICommand
    {
        // Receiver Paddle
        public Paddle Paddle;
        public int previous;

        public LeftCommand(Paddle paddle)
        {
            Paddle = paddle;
        }

        public void Execute()
        {
            previous = Paddle.GetX();
            Paddle.Move("Left");
        }

        public void Undo()
        {
            Paddle.SetX(previous);
        }
    }
}
