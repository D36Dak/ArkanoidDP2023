namespace Arkanoid.Data.Mediator
{
    public class WordExpression:Expression
    {
        public string Word;
        public WordExpression(string word)
        {
            this.Word = word;
        }

        public override void Interpret(string context)
        {
            context = context + Word + " ";
        }
    }
}
