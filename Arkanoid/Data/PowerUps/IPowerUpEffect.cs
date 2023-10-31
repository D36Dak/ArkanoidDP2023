namespace Arkanoid.Data.PowerUps
{
    public interface IPowerUpEffect
    {
        void ApplyEffect(PowerUp implementor);
        void RemoveEffect(PowerUp implementor);
    }
}
