using System;
using System.IO;
using NLog;

namespace CustomRoyale
{
    public class Logger
    {
#if DEBUG
        private static readonly object ConsoleSync = new object();
#endif

        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        public Logger()
        {
            Directory.CreateDirectory("Logs");
        }

       public static void Log(object message, ErrorLevel logType = ErrorLevel.Info)
        {
            switch (logType)
            {
                case ErrorLevel.Info:
                {
                    _logger.Info(message);
                    Console.WriteLine($"[{logType.ToString()} - {DateTime.Now.ToString("yyyy-MM-dd")}] {DateTime.Now.ToString(" HH:mm:ss")}] : {message}");
                    break;
                }

                case ErrorLevel.Warning:
                {
                    _logger.Warn(message);
        #if DEBUG
                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine($"[{logType.ToString()} - {DateTime.Now.ToString("yyyy-MM-dd")}] {DateTime.Now.ToString(" HH:mm:ss")}] : {message}");
                        Console.ResetColor();
                    }
        #endif
                    break;
                }

                case ErrorLevel.Error:
                {
                    _logger.Error(message);
        #if DEBUG
                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{logType.ToString()} - {DateTime.Now.ToString("yyyy-MM-dd")}] {DateTime.Now.ToString(" HH:mm:ss")}] : {message}");
                        Console.ResetColor();
                    }
        #endif
                    break;
                }

                case ErrorLevel.Debug:
                {
        #if DEBUG
                    _logger.Debug(message);
                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"[{logType.ToString()} - {DateTime.Now.ToString("yyyy-MM-dd")}] {DateTime.Now.ToString(" HH:mm:ss")}] : {message}");
                        Console.ResetColor();
                    }
        #endif
                    break;
                }
            }
        }

    } 
}