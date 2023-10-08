namespace Arkanoid.Data.Tiles
{
    public class TileFactory
    {
        public enum TileType { Regular, Hard, Explosive }
        public Tile CreateTile(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Regular:
                    break;
                    // cant get the ball, cant get singleton what is this navigation?
                    //return new RegularTile()
            }
            throw new NotImplementedException();
        }
    }
}
