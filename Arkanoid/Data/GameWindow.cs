namespace Arkanoid.Data
{
    public class GameWindow
    {
        private int Width = 1280;
        private int Height = 720;

        public GameWindow() { }
        public GameWindow(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int GetWidth()
        {
            return Width;
        }
        public int GetHeight()
        {
            return Height;
        }
    }
}
