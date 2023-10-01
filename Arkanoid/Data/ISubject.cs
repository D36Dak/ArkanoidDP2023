namespace Arkanoid.Data
{
    public interface ISubject
    {
        public void Attach(IObserver observer);
        public void UnAttach(IObserver observer);
        public void NotifyAll();
    }
}
