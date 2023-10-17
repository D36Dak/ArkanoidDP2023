namespace Arkanoid.Data.PowerUps
{
    public class PowerUpDirector
    {
        public PowerUp Construct(IPowerUpBuilder builder, int x, int y, string color, int size)
        {
            builder.SetPosition(x, y);
            builder.SetColor(color);
            builder.SetSize(size);
            return builder.Build();
        }
    }

}
