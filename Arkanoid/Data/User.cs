using Arkanoid.Data.Mediator;
namespace Arkanoid.Data
{
    public abstract class User
    {
        protected ChatMediator m;
        public string name;
        public List<string> messages = new List<string>();

        public abstract void SendMessage(string message);
        public abstract void ReceiveMessage(string message);
    }
}
