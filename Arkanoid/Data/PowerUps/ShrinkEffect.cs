namespace Arkanoid.Data.PowerUps
{
    public class ShrinkEffect : IPowerUpEffect
    {
        private Paddle paddle;
        private int originalWidth;

        public ShrinkEffect(Paddle paddle)
        {
            this.paddle = paddle;
            this.originalWidth = paddle.GetWidth();
        }

        public void ApplyEffect()
        {
            // Store the original width before changing
            originalWidth = paddle.GetWidth();

            // shrink the paddle
            paddle.SetX(paddle.GetX() + (int)(originalWidth * 0.25)); // Adjust the X position
            paddle.SetWidth((int)(originalWidth * 0.5));  // Decrease the width by 50%
        }

        public void RemoveEffect()
        {
            // revert the paddle to original size
            paddle.SetX(paddle.GetX() - (int)(originalWidth * 0.25)); // Revert the X position
            paddle.SetWidth(originalWidth);
        }
    }

}
