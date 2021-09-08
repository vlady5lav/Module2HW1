using System;
using System.Text;

namespace TestLogger
{
    public enum LogLvl
    {
        Info,
        Warning,
        Error
    }

    public sealed class Logger
    {
        private static readonly StringBuilder _log = new ();

        private static readonly Logger _instance = new ();

        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance => _instance;

        public static string Log => _log.ToString();

        public void LogEvent(LogLvl lvl, string msg)
        {
            var logMsg = $"{DateTime.Now}: {lvl}: {msg}";

            Console.WriteLine(logMsg);
            _log.AppendLine(logMsg);
        }

        public void LogEventInfo(string msg)
        {
            LogEvent(LogLvl.Info, msg);
        }

        public void LogEventWarning(string msg)
        {
            LogEvent(LogLvl.Warning, msg);
        }

        public void LogEventError(string msg)
        {
            LogEvent(LogLvl.Error, msg);
        }
    }
}
