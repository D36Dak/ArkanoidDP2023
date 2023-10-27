namespace Arkanoid.Data
{
    public interface IPrototype<T>
    {
        public T Clone();
        //public T DeepCopy();
    }
}
