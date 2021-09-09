using System;
using System.Text;

namespace TestLogger
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();

        private readonly StringBuilder _log = new StringBuilder();

        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance => _instance;

        public string Log => _log.ToString();

        public void LogEvent(LogLevel logLevel, string msg)
        {
            var logMsg = $"{DateTime.UtcNow}: {logLevel}: {msg}";

            Console.WriteLine(logMsg);
            _log.AppendLine(logMsg);
        }

        public void LogEventInfo(string msg)
        {
            LogEvent(LogLevel.Info, msg);
        }

        public void LogEventWarning(string msg)
        {
            LogEvent(LogLevel.Warning, msg);
        }

        public void LogEventError(string msg)
        {
            LogEvent(LogLevel.Error, msg);
        }
    }
}
