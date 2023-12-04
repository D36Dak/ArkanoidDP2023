using Arkanoid.Data.Mediator;

namespace Arkanoid.Data
{
    public class Spectator : User
    {
        public Spectator(string name)
        {
            this.name = name;
            this.m = ChatMediator.GetInstance();
            m.AddUser(this);
        }
        public override void ReceiveMessage(string message)
        {
            this.messages.Add(message);
        }

        public override void SendMessage(string message)
        {
            m.Broadcast(this, message);
        }
    }
}
