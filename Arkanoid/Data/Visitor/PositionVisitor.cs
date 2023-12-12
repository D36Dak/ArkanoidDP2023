using Arkanoid.Data.Tiles;

namespace Arkanoid.Data.Visitor
{
    public class PositionVisitor : IVisitor
    {
        public void Visit(RegularTile tile)
        {
            var ge = GameEngine.GetInstance();
            // float prcScore =(float)(ge.GetWindowHeight() - tile.Position.Y)/ge.GetWindowHeight();
            int extraScore = (int)MathF.Sqrt((ge.GetWindowHeight() - tile.Position.Y));
            
            
         
            ge.Score += 10 + extraScore;
        }

        public void Visit(ExplodingTile tile)
        {
            var ge = GameEngine.GetInstance();
            // float prcScore =(float)(ge.GetWindowHeight() - tile.Position.Y)/ge.GetWindowHeight();
            int extraScore = (int)MathF.Sqrt((ge.GetWindowHeight() - tile.Position.Y));



            ge.Score += 10 + extraScore;
        }

        public void Visit(HardTile tile)
        {
            var ge = GameEngine.GetInstance();
            // float prcScore =(float)(ge.GetWindowHeight() - tile.Position.Y)/ge.GetWindowHeight();
            int extraScore = (int)MathF.Sqrt((ge.GetWindowHeight() - tile.Position.Y));



            ge.Score += 10 + extraScore;
        }
    }
}
