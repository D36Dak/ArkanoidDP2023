namespace Arkanoid.Data
{
    public class Paddle
    {
        private int X;
        private int Width = 200;
        private int Height = 20;

        public Paddle(int x)
        {
            X = x;
        }
        public int GetWidth()
        {
            return Width;
        }
        public int GetHeight()
        {
            return Height;
        }
        public int GetX()
        {
            return X;
        }
        public void SetX(int x)
        {
            X = x;
        }
        public void MoveLeft()
        {
            X += 5;
        }
        public void MoveRight()
        {
            X -= 5;
        }
    }
}
