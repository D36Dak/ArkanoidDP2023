namespace Arkanoid.Data.Mediator
{
    public class ChatMediator : IMediator
    {
        private List<User> users = new List<User>();
        private static ChatMediator instance;
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void Broadcast(User sender, string message)
        {
            if (sender is Player)
            {
                foreach (var user in users)
                {
                    user.ReceiveMessage(message);
                }
                //send to everyone
            } else
            {
                foreach (var user in users)
                {
                    if (user is Spectator)
                    {
                        user.ReceiveMessage(message);
                    }
                }
                //send to spectators only 
            }
            return;
        }
        public static ChatMediator GetInstance()
        {
            instance??=new ChatMediator();
            return instance;
        }
    }
}
