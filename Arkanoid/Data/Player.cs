using Arkanoid.Data.Mediator;

namespace Arkanoid.Data
{
    public enum Side
    {
        LEFT, RIGHT
    }
    public class Player: User
    {

        public string id { get; set; }
        public Side side { get; set; } = Side.LEFT;

        public Player(string id, Side side)
        {
            this.m = ChatMediator.GetInstance();
            this.id = id;
            this.side = side;
            if (side == Side.LEFT)
            {
                this.name = "Player1";
            } else
            {
                this.name = "Player2";
            }
            m.AddUser(this);
        }

        public override void SendMessage(string message)
        {
            m.Broadcast(this, message);
        }

        public override void ReceiveMessage(string message)
        {
            this.messages.Add(message);
        }
    }
}
