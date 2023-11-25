namespace Arkanoid.Data.Logger
{
    public class InfoLogger : Logger
    {
        public InfoLogger(Logger? nextLogger = null) {
            next = nextLogger;
        }

        public override void Log(string message, LogLevel level)
        {
            if(level == LogLevel.INFO)
            {
                ConsoleColor prevCol = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("INFO");
                Console.ForegroundColor = prevCol;
                Console.WriteLine($": {message}");
            } else next?.Log(message, level);
        }
    }
}
