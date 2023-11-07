using Arkanoid.Data.PowerUps;
using Arkanoid.Data.Tiles.Decorator;
using System.Drawing;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public abstract class Tile : Component, IObserver
    {

        public Tile(Ball ball, string color, Vector2 position, int hp = 1, Decorator.Decorator? decorator = null) : base(color, position, ball, decorator, hp)
        {
        }

    }
}
