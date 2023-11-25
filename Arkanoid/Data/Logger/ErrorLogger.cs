namespace Arkanoid.Data.Logger
{
    public class ErrorLogger : Logger
    {
        public ErrorLogger(Logger? nextLogger = null)
        {
            next = nextLogger;
        }

        public override void Log(string message, LogLevel level)
        {
            if (level == LogLevel.ERROR)
            {
                ConsoleColor prevCol = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR");
                Console.ForegroundColor = prevCol;
                Console.WriteLine($": {message}");
            } else next?.Log(message, level);
        }
    }
}
