namespace Arkanoid.Data.PowerUps
{
    public class ExpandEffect : IPowerUpEffect
    {
        private Paddle paddle;
        private int originalWidth;

        public ExpandEffect()
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

            // expand the paddle
            paddle.SetX(paddle.GetX() - (int)(originalWidth * 0.25)); // Adjust the X position
            paddle.SetWidth((int)(originalWidth * 1.5));  // Increase the width by 50%
        }

        public void RemoveEffect(PowerUp implementor)
        {
            // revert the paddle to original size
            paddle.SetX(paddle.GetX() + (int)(originalWidth * 0.25)); // Revert the X position
            paddle.SetWidth(originalWidth);
        }
    }

}
