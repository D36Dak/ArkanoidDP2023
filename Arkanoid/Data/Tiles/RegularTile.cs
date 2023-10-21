﻿using Arkanoid.Data.Tiles.Decorator;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public class RegularTile : Tile
    {
        public RegularTile(Ball ball, string color, Vector2 position, int hp = 1) : base(ball, color, position, hp)
        {
        }

        public override void OnHit(Component tile, Ball ball)
        {
            // fix singleton for GameEngine first
            var bounceDir = Linear.GetBounceOffDirection(tile, ball);
            GameEngine.GetInstance().InvertBallDirection(bounceDir);
            // destroy this tile. cheap but effective
            //Console.WriteLine(bounceDir);
            tile.HP -= 1;
            if(tile.HP <= 0)
            {
                tile.HP = 0;
                GameEngine.GetInstance().tm?.DestroyTile(tile);
            }
        }
    }
}
