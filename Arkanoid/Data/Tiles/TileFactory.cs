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
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
