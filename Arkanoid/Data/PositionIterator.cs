using Arkanoid.Data.Adapter;

namespace Arkanoid.Data
{
    public class PositionIterator : Iterator 
    {
        private MovableManager _movableManager;
        private List<IMovable> _sortedMovables;
        private int _current = 0;

        public PositionIterator(MovableManager movableManager)
        {
            _movableManager = movableManager;
        }

        public override object First()
        {
            
            _sortedMovables = _movableManager.GetMovables().OrderBy(movable => movable.GetPositionY()).ToList();
            _current = 0;
            return _sortedMovables.Count > 0 ? _sortedMovables[_current] : null;
        }

        public override object Next()
        {
            _current++;
            if (!IsDone())
            {
                return _sortedMovables[_current];
            }
            else
            {
                return null;
            }
        }

        public override bool IsDone()
        {
            return _current >= _sortedMovables.Count;
        }

        public override object CurrentItem()
        {
            if (IsDone())
            {
                throw new InvalidOperationException("Iterator out of bounds");
            }
            return _sortedMovables[_current];
        }
    }
}
