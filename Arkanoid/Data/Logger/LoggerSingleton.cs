namespace Arkanoid.Data.Logger
{
    public enum LogLevel { INFO, WARN, ERROR };
    public class LoggerSingleton
    {
        private static LoggerSingleton? instance;
        private static volatile object locker = new();
        private readonly Logger logger;
        public static LoggerSingleton GetInstance()
        {
            lock (locker)
            {
                instance ??= new LoggerSingleton();
                return instance;
            }
        }

        public LoggerSingleton()
        {
            logger = new InfoLogger(
                new WarningLogger(
                    new ErrorLogger()
                )
            );
        }

        public void Log(string message, LogLevel level)
        {
            logger.Log(message, level);
        }
    }
}
