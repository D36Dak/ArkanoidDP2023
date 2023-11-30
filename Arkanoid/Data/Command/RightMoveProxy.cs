namespace Arkanoid.Data.Command
{
    public class RightMoveProxy : ICommand
    {
        private readonly Paddle _paddle;
        private readonly ICommand _rightCommand;

        public RightMoveProxy(Paddle paddle)
        {
            _paddle = paddle;
            _rightCommand = new RightCommand(_paddle);
        }

        public void Execute()
        {
            // Check if moving right will keep the paddle within the boundary
            if (_paddle.GetX() < (1280 - _paddle.GetWidth()))
            {
                _rightCommand.Execute(); // Execute the RightCommand
            }
        }

        public void Undo()
        {
            _rightCommand.Undo();
        }
    }
}
