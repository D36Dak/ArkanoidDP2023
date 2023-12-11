namespace Arkanoid.Data
{
    public class MovableIterator: Iterator
    {
        private MovableManager _movableManager;
        private int _current = 0;

        
        public MovableIterator(MovableManager movableManager)
        {
            this._movableManager = movableManager;
        }

        public override object First()
        {
            _current = 0;
            return _movableManager[_current];
        }

        public override object Next()
        {
            _current++;
            if (!IsDone())
            {
                return _movableManager[_current];
            }
            else
            {
                return null;
            }
        }

        public override bool IsDone()
        {
            return _current >= _movableManager.Count;
        }

        public override object CurrentItem()
        {
            return _movableManager[_current];
        }
    }
}
