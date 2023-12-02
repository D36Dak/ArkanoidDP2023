using Arkanoid.Data.PowerUps;
using Arkanoid.Data.Tiles.Decorator;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public enum TileType { Regular, Hard, Explosive }
    public class TileFactory
    {
        
        private Random random = new();
        public Component CreateTile(TileType tileType, Vector2 pos)
        {
            switch (tileType)
            {
                case TileType.Regular:
                    var tile = new RegularTile(GameEngine.GetInstance().Ball, "green", pos, random.Next(1, 4));
                    var dec = new ChangeColor(tile);
                    return dec;
                case TileType.Hard:
                    return new HardTile(GameEngine.GetInstance().Ball, "gray", pos);
                case TileType.Explosive:
                    return new ExplodingTile(GameEngine.GetInstance().Ball, "yellow", pos);
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        //public Component Clone(Component originalTile)
        //{
        //    if (originalTile is RegularTile regularTile)
        //    {
        //        // Clone a RegularTile
        //        return new RegularTile(GameEngine.GetInstance().Ball, regularTile.Color, regularTile.Position, regularTile.HP);
        //    }
        //    else if (originalTile is HardTile hardTile)
        //    {
        //        // Clone a HardTile
        //        return new HardTile(GameEngine.GetInstance().Ball, hardTile.Color, hardTile.Position);
        //    }
        //    // Handle other tile types if needed
        //    throw new NotImplementedException();
        //}

        public Component Clone(Component tile)
        {
            if (tile is HardTile hardTile)
            {
                return hardTile.Clone();
            }
            else if (tile is RegularTile regularTile)
            {
                return regularTile.Clone();
            }
            // Add cases for other tile types if needed

            return null; // Handle unknown tile types
        }
    }
}
