namespace Arkanoid.Data.Logger
{
    public abstract class Logger
    {
        protected LogLevel _level;
        protected Logger? next;

        public abstract void Log(string message, LogLevel level);
    }
}
