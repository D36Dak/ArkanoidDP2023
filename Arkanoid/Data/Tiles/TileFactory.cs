using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public enum TileType { Regular, Hard, Explosive }
    public class TileFactory
    {
        public Tile CreateTile(TileType tileType, Vector2 pos)
        {
            switch (tileType)
            {
                case TileType.Regular:
                    return new RegularTile(GameEngine.GetInstance().Ball, "green", pos);
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
