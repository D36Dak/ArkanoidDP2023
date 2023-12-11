namespace Arkanoid.Data.Mediator
{
    public class ChatInterpreter
    {
        private List<Expression> expressions = new List<Expression>();
        public ChatInterpreter() { }
        public void ParseMessage(string message)
        {
            expressions.Clear();
            string[] words = message.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(words[i])) continue;
                if (i+1<words.Length &&
                    (words[i].ToLower().Equals("take") || words[i].ToLower().Equals("give")))
                {
                    WordExpression e1 = new WordExpression(words[i]);
                    WordExpression e2 = new WordExpression(words[i+1]);
                    expressions.Add(new CheatExpression(e1, e2));
                }
                expressions.Add(new WordExpression(words[i]));
            }
        }
        public string Interpret()
        {
            string result = "";
            foreach (var expression in expressions) { expression.Interpret(result); }
            return result;
        }
    }
}
