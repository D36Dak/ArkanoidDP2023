namespace Arkanoid.Data.Mediator
{
    public interface IMediator
    {
        public void AddUser(User user);
        public void Broadcast(User sender, string message);
    }
}
