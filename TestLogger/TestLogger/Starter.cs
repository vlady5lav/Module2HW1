using System;

namespace TestLogger
{
    public class Starter
    {
        private readonly Actions _actions = new ();

        private readonly Logger _logger = Logger.Instance;

        private readonly int _cycles = 100;
        private readonly int _maxRnd = 3;

        private readonly Random _rnd = new ();

        private readonly string _logFileFormat = ".txt";

        private string _timeStamp;
        private string _logName;

        public void Run()
        {
            Console.WriteLine("Please, select log filename style:\nPress 1 if you want timestamped log filename\nPress 2 if you want simple \"log.txt\" filename\n");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        _timeStamp = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HH'-'mm'-'ss");
                        _logName = "log_";
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        _timeStamp = string.Empty;
                        _logName = "log";
                        break;
                    default:
                        Console.WriteLine("Please, make your choice!\n");
                        continue;
                }

                break;
            }

            var filename = $"{_logName}{_timeStamp}{_logFileFormat}";

            for (var i = 0; i < _cycles; i++)
            {
                var res = new Result();

                var rndAct = _rnd.Next(_maxRnd);

                switch (rndAct)
                {
                    case 0:
                        res = _actions.InfoLog();
                        break;
                    case 1:
                        res = _actions.WarningLog();
                        break;
                    case 2:
                        res = _actions.ErrorLog();
                        break;
                }

                if (!res.Status)
                {
                    _logger.LogEventError($"Action failed by a reason: {res.ErrMsg}");
                }
            }

            FileService.Write2File($"{filename}", Logger.Log);

            Console.WriteLine($"\nLog has been successfully written to the file \"{FileService.GetCurrentDir()}\\{filename}\"\n");

            Console.Write("Do you want to open log now? [Y]es/[N]o");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Y:
                        FileService.OpenFile($"{filename}");
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.N:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("\n\nPlease, make your choice!\nDo you want to open log now? [Y]es/[N]o");
                        continue;
                }
            }
        }
    }
}
