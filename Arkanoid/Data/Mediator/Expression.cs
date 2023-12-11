using System.Text;

namespace Arkanoid.Data.Mediator
{
    public abstract class Expression
    {
        public abstract void Interpret(string context);
    }
}
