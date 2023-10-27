﻿using Microsoft.AspNetCore.SignalR.Client;
using System.ComponentModel;
using System.Numerics;

namespace Arkanoid.Data.Tiles.Decorator
{
    public class ChangeColor : Decorator
    {
        readonly string[] colors = { "blue", "red", "purple", "orange", "yellow", "cyan", "green" };
        readonly Random random = new();

        public ChangeColor(Component component) : base(component)
        {
            Color = colors[HP];
        }

        public override void OnHit(Component tile, Ball ball)
        {
            base.OnHit(tile, ball);
            Color = colors[HP];
            Console.WriteLine($"HP left: {HP} | {Color}");
            //tile.TileManager.Connection.SendAsync("TileColor", tile.Position.X, tile.Position.Y, colors[random.Next(0, colors.Length)], tile.TileManager.Connection.ConnectionId);

        }

        //public override Component Clone()
        //{
        //    //return new ChangeColor(Component); // reik sukurt cia tile, bet xz
        //    return (Component)this.MemberwiseClone();
        //}
        public override Component Clone()
        {
            //return new RegularTile(Ball, Color, Position, HP);
            Component c = (Component)this.MemberwiseClone();
            Ball.Attach(c);
            return c;
        }

        public override Component DeepCopy()
        {
            var newChangeColor = Clone();

            return newChangeColor;
        }
    }
}
