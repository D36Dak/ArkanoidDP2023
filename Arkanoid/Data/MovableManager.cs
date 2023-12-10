using Arkanoid.Data.Adapter;

namespace Arkanoid.Data
{
    public class MovableManager
    {
        private List<IMovable> movables = new List<IMovable>();

        public MovableIterator CreateIterator()
        {
            return new MovableIterator(this);
        }
        public List<IMovable> GetMovables()
        {
            return movables;
        }
        public void AddMovable(IMovable movable)
        {
            movables.Add(movable);
        }

        public void RemoveMovable(IMovable movable)
        {
            movables.Remove(movable);
        }

        public IMovable this[int index]
        {
            get => movables[index];
            set
            {
                if (index >= 0 && index < movables.Count)
                {
                    movables[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range for MovableManager");
                }
            }
        }

        public int Count => movables.Count;
    }

}
