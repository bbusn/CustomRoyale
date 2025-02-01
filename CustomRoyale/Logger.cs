using NLog;

namespace CustomRoyale
{
    public class Logger
    {
        private static readonly object ConsoleSync = new object();

        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public Logger()
        {
            Directory.CreateDirectory("Logs");
        }

        public static void Log(object message, ErrorLevel logType = ErrorLevel.Info)
        {
            LogToNLog(message, logType);
        #if DEBUG
            LogToConsole(message, logType);
        #endif
        }

        private static void LogToNLog(object message, ErrorLevel logType)
        {
            switch (logType)
            {
                case ErrorLevel.Info:
                    _logger.Info(message);
                    break;
                case ErrorLevel.Warning:
                    _logger.Warn(message);
                    break;
                case ErrorLevel.Error:
                    _logger.Error(message);
                    break;
                case ErrorLevel.Debug:
                #if DEBUG
                    _logger.Debug(message);
                #endif
                    break;
            }
        }

        private static void LogToConsole(object message, ErrorLevel logType)
        {
            lock (ConsoleSync)
            {
                SetConsoleColor(logType);
                ConsoleWriteLine(message, logType);
                Console.ResetColor();
            }
        }

        private static void SetConsoleColor(ErrorLevel logType)
        {
            switch (logType)
            {
                case ErrorLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case ErrorLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ErrorLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }

        public static void ConsoleWriteLine(object message, ErrorLevel logType = ErrorLevel.Info)
        {
            Console.WriteLine($"[{logType}][{DateTime.Now:yyyy-MM-dd HH:mm:ss}] : {message}");
        }
    }
}