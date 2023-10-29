namespace Arkanoid.Data.Command
{
    public class PaddleController
    {
        private ICommand command;
        private ICommand previousCommand;

        public PaddleController()
        {
            // Initialize the controller with no initial command
            command = null;
            previousCommand = null;
        }

        public void SetCommand(ICommand command)
        {
            previousCommand = command; // Store the previous command for undo
            command = command;
        }

        public void Invoke()
        {
            if (command != null)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            if (previousCommand != null)
            {
                command = previousCommand; // Restore the previous command for redo
                previousCommand = null;
                command.Undo();
            }
        }
    }
}
