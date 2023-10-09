﻿using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position) : base(ball, color, position)
        {
        }

        public override void OnHit()
        {
            // fix singleton for GameEngine first
            var bounceDir = GetBounceOffDirection();
            if (bounceDir == BounceDir.Horizontal) ball.InvertX();
            else ball.InvertY();
            // destroy this tile. cheap but effective
            GameEngine.GetInstance().Tiles.Remove(this);
        }
    }
}
