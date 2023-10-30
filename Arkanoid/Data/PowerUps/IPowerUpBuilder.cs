namespace Arkanoid.Data.PowerUps
{
    public interface IPowerUpBuilder
    {
        IPowerUpBuilder SetPosition(int x, int y);
        IPowerUpBuilder SetColor(string color);
        IPowerUpBuilder SetSize(int size);
        PowerUp Build();
    }
}
