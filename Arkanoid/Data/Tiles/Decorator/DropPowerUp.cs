namespace Arkanoid.Data.Tiles.Decorator
{
    public class DropPowerUp :Decorator
    {
        public override void OnHit(Tile tile, Ball ball)
        {
            base.OnHit(tile, ball);
            // instantiate power up and add it to dropping list or something...
        }
    }
}
