using System.Text;
using System.Text.RegularExpressions;

namespace Arkanoid.Data.Mediator
{
    public class CheatExpression:Expression
    {
        WordExpression Left;
        WordExpression Right;
        public CheatExpression(WordExpression left, WordExpression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override void Interpret(StringBuilder context)
        {
            if (Left.Word.ToLower().Equals("give"))
            {
                InterpretGive(context);
                return;
            }
            if (Left.Word.ToLower().Equals("take"))
            {
                InterpretTake(context);
            }
        }

        private void InterpretGive(StringBuilder context)
        {
            if (Right.Word.ToLower().Equals("hp"))
            {
                GiveHp();
                context.Clear();
                context.Append("You got infinite HP");
            }
            else if (Right.Word.ToLower().Equals("size"))
            {
                GiveSize();
                context.Clear();
                context.Append("You got maximum paddle width");
            }
            else
            {
                //if cheat incorrect, interpret as text
                Left.Interpret(context);
                Right.Interpret(context);
            }
        }
        private void InterpretTake(StringBuilder context)
        {
            if (Right.Word.ToLower().Equals("hp"))
            {
                TakeHp();
                context.Clear();
                context.Append("HP got reset to normal");
            }
            else if (Right.Word.ToLower().Equals("size"))
            {
                TakeSize();
                context.Clear();
                context.Append("Paddle width got reset to normal");
            }
            else
            {
                //if cheat incorrect, interpret as text
                Left.Interpret(context);
                Right.Interpret(context);
            }
        }

        /// <summary>
        /// Gives infinite hp
        /// </summary>
        private void GiveHp()
        {
            GameEngine.GetInstance().CheatsSetHP(int.MaxValue);
        }
        /// <summary>
        /// Takes away infinite hp
        /// </summary>
        private void TakeHp()
        {
            GameEngine.GetInstance().CheatsSetHP(3);
        }
        /// <summary>
        /// Gives paddles maximum width
        /// </summary>
        private void GiveSize()
        {
            GameEngine.GetInstance().CheatsSetSize(600);
        }
        /// <summary>
        /// Takes away maximum width from paddles
        /// </summary>
        private void TakeSize()
        {
            GameEngine.GetInstance().CheatsSetSize(200);
        }
    }
}
