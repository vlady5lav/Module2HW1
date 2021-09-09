using System;

namespace TestLogger
{
    public class Actions
    {
        private readonly Logger _logger = Logger.Instance;

        public Result InfoLog()
        {
            _logger.LogEventInfo($"Start method: {nameof(InfoLog)}");
            return new Result() { Status = true };
        }

        public Result WarningLog()
        {
            _logger.LogEventWarning($"Skipped logic in method: {nameof(WarningLog)}");
            return new Result() { Status = true };
        }

        public Result ErrorLog()
        {
            return new Result() { ErrorMsg = "I broke a logic." };
        }
    }
}
