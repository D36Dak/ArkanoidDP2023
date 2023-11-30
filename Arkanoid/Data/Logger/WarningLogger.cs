namespace Arkanoid.Data.Logger
{
    public class WarningLogger : Logger
    {
        public WarningLogger(Logger? nextLogger = null) {
            next = nextLogger;
        }

        public override void Log(string message, LogLevel level)
        {
            if (level == LogLevel.WARN)
            {
                ConsoleColor prevCol = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("WARN");
                Console.ForegroundColor = prevCol;
                Console.WriteLine($": {message}");
            } else next?.Log(message, level);
        }
    }
}
