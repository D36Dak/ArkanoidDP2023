using Arkanoid.Data.Tiles;
using System.Numerics;

namespace Arkanoid.Data
{
    public enum BounceDir { Vertical, Horizontal }
    public static class Linear
    {
        public static Vector3 GetLineCoeffs(Vector2 p1, Vector2 p2)
        {
            //Ax + Bx + C = 0
            float a = p1.Y - p2.Y;
            float b = p2.X - p1.X;
            float c = p1.X * p2.Y - p2.X * p1.Y;
            return new Vector3(a, b, c);
        }

        public static float LineY(Vector3 coeffs, float x)
        {
            return -(coeffs.X * x + coeffs.Z) / coeffs.Y;
        }

        public static float LineX(Vector3 coeffs, float y)
        {
            
            return -(coeffs.Y * y + coeffs.Z) / coeffs.X;
        }

        public static BounceDir GetBounceOffDirection(Tile tile, Ball ball)
        {
            Vector3 Line1Coeffs = GetLineCoeffs(tile.Position, new Vector2(tile.Position.X + tile.Width, tile.Position.Y + tile.Height));

            Vector3 Line2Coeffs = GetLineCoeffs(new Vector2(tile.Position.X, tile.Position.Y + tile.Height), new Vector2(tile.Position.X + tile.Width, tile.Position.Y));
            var Line1Y = LineY(Line1Coeffs, ball.GetX());
            var Line2Y = LineY(Line2Coeffs, ball.GetX());

            // hit is from the top or the bottom
            if (Line1Y > ball.GetY() && Line2Y > ball.GetY() || Line1Y < ball.GetY() && Line2Y < ball.GetY())
            {

                return BounceDir.Vertical;
            }
            // hit can only be horizontal now now
            else
            {

                return BounceDir.Horizontal;
            }
        }
    }
}
