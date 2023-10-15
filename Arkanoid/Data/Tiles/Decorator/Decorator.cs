namespace Arkanoid.Data.Tiles.Decorator
{
    public abstract class Decorator : Component
    {
        protected Component? Component;
        public void SetComponent(Component component)
        {
            Component = component;
        }
        public override void OnHit(Tile tile, Ball ball)
        {
            Component?.OnHit(tile, ball);
        }
    }
}
