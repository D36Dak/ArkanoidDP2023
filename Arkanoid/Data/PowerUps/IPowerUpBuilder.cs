namespace Arkanoid.Data.PowerUps
{
    public interface IPowerUpBuilder
    {
        void SetPosition(int x, int y);
        void SetColor(string color);
        void SetSize(int size);
        PowerUp Build();
    }
}
