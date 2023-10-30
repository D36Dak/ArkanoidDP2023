using Arkanoid.Data.PowerUps;
using Arkanoid.Data.Tiles.Decorator;
using System.Numerics;

namespace Arkanoid.Data.Tiles
{
    public enum TileType { Regular, Hard, Explosive }
    public class TileFactory
    {
        
        private Random random = new();
        public Tile CreateTile(TileType tileType, Vector2 pos, TileManager tm, IPowerUpEffect powerUpEffect)
        {
            switch (tileType)
            {
                case TileType.Regular:
                    var tile = new RegularTile(GameEngine.GetInstance().Ball, "green", pos, tm, powerUpEffect);
                    var dec = new ChangeColor();
                    dec.SetComponent(tile);
                    tile.Decorator = dec;
                    return tile;
                case TileType.Hard:
                    return new HardTile(GameEngine.GetInstance().Ball, "gray", pos, tm, powerUpEffect);
                case TileType.Explosive:
                    // Čia galite pridėti kodą, jei reikia
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
