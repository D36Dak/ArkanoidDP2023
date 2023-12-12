using Arkanoid.Data.Tiles;

namespace Arkanoid.Data.Visitor
{
    public interface IVisitor
    {
        void Visit(RegularTile tile);
        void Visit(ExplodingTile tile);
        void Visit(HardTile tile);



    }
}
