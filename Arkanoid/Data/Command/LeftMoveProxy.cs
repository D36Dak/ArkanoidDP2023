namespace Arkanoid.Data.Command
{
    public class LeftMoveProxy : ICommand
    {
        private readonly Paddle _paddle;
        private readonly ICommand _leftCommand;

        public LeftMoveProxy(Paddle paddle)
        {
            _paddle = paddle;
            _leftCommand = new LeftCommand(_paddle);
        }

        public void Execute()
        {
            // Check if moving left will keep the paddle within the boundary
            if (_paddle.GetX() >= 0)
            {
                _leftCommand.Execute(); // Execute the LeftCommand
            }
        }

        public void Undo()
        {
            _leftCommand.Undo();
        }
    }
}
