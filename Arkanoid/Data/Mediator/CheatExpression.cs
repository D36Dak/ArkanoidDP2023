namespace Arkanoid.Data.Mediator
{
    public class CheatExpression
    {
        WordExpression left;
        WordExpression right;
        public CheatExpression(WordExpression left, WordExpression right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
