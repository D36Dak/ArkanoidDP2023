namespace Arkanoid.Data.Command
{
    public class PaddleController
    {
        private ICommand _command;
        private ICommand _previousCommand;

        public PaddleController()
        {
            // Initialize the controller with no initial command
            _command = null;
            _previousCommand = null;
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }


        public void Undo()
        {
            if (_previousCommand != null)
            {
                _command = _previousCommand; // Restore the previous command for redo
                _previousCommand = null;
                _command.Undo();
            }
        }

        public void Invoke()
        {
            if (_command != null)
            {
                _previousCommand = _command; // Store the current command as previous
                _command.Execute();
            }
        }
    }
}
