namespace Arkanoid.Data
{
    public enum Side
    {
        LEFT, RIGHT
    }
    public class Player
    {

        public string id { get; set; }
        public Side side { get; set; } = Side.LEFT;

        public Player(string id, Side side)
        {
            this.id = id;
            this.side = side;
        }
    }
}
