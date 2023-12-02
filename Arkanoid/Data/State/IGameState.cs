namespace Arkanoid.Data.State
{
    public interface IGameState
    {
        public string GetMessage();
        public void Action();
    }
}
