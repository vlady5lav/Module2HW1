using System;

namespace TestLogger
{
    public class Starter
    {
        private const int Cycles = 100;
        private const int MaxRnd = 3;

        private const string LogFileName = "log.txt";

        private readonly Actions _actions = new Actions();
        private readonly FileService _fileService = new FileService();
        private readonly Random _rnd = new Random();

        private readonly Logger _logger = Logger.Instance;

        public void Run()
        {
            for (var i = 0; i < Cycles; i++)
            {
                var result = new Result();

                var rnd = _rnd.Next(MaxRnd);

                switch (rnd)
                {
                    case 0:
                        result = _actions.InfoLog();
                        break;
                    case 1:
                        result = _actions.WarningLog();
                        break;
                    case 2:
                        result = _actions.ErrorLog();
                        break;
                }

                if (!result.Status)
                {
                    _logger.LogEventError($"Action failed by a reason: {result.ErrorMsg}");
                }
            }

            _fileService.WriteToFile($"{LogFileName}", _logger.Log);

            Console.WriteLine($"\nLog has been successfully written to the file \"{_fileService.GetCurrentDir()}\\{LogFileName}\"\n");

            Console.ReadKey();
        }
    }
}
