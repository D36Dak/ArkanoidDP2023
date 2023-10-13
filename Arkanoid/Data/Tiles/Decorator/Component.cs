namespace Arkanoid.Data.Tiles.Decorator
{
    public abstract class Component
    {
        public abstract void OnHit(Tile tile, Ball ball);
    }
}
