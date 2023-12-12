using Arkanoid.Data.Tiles;

namespace Arkanoid.Data.Visitor
{
    public class DefaultVisitor : IVisitor
    {
        public void Visit(RegularTile tile)
        {
            GameEngine.GetInstance().Score += 10;
        }

        public void Visit(ExplodingTile tile)
        {
            GameEngine.GetInstance().Score += 50;
        }

        public void Visit(HardTile tile)
        {
            GameEngine.GetInstance().Score += 1;
        }
    }
}
