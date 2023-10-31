namespace Arkanoid.Data.PowerUps
{
    public class ShrinkEffect : IPowerUpEffect
    {
        private Paddle paddle;
        private int originalWidth;

        public ShrinkEffect()
        {
            
        }

        public void ApplyEffect(PowerUp implementor)
        {
            paddle = implementor.Catcher;
            if (paddle == null)
            {
                return;
            }
            // Store the original width before changing
            originalWidth = paddle.GetWidth();

            // shrink the paddle
            paddle.SetX(paddle.GetX() + (int)(originalWidth * 0.25)); // Adjust the X position
            paddle.SetWidth((int)(originalWidth * 0.5));  // Decrease the width by 50%
        }

        public void RemoveEffect(PowerUp implementor)
        {
            // revert the paddle to original size
            paddle.SetX(paddle.GetX() - (int)(originalWidth * 0.25)); // Revert the X position
            paddle.SetWidth(originalWidth);
        }

    }

}
