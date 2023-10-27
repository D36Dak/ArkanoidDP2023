using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace Arkanoid.Data.Tiles.Decorator
{
    public abstract class Decorator : Component
    {
        protected Component Component;

        protected Decorator(Component component) : base(component.Color, component.Position, component.Ball, component.Decorator, component.HP, component.Width, component.Height)
        {
            Ball.UnAttach(component);
            Component = component;
        }

        protected Decorator(string color, Vector2 position, Ball ball, Decorator decorator, int hp, int width, int height, Component component)
        : base(color, position, ball, decorator, hp, width, height)
        {
            Ball.UnAttach(component);
            Component = component;
        }

        public override void OnHit(Component tile, Ball ball)
        {
            Component.OnHit(tile, ball);
        }

    }
}
