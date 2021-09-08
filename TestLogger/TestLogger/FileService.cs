using System;
using System.IO;
using System.Diagnostics;

namespace TestLogger
{
    public class FileService
    {
        public static void Write2File(string path, string log)
        {
            File.WriteAllText(path, log);
        }

        public static string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }

        public static void OpenFile(string filename)
        {
            Process.Start(new ProcessStartInfo { FileName = $"{GetCurrentDir()}\\{filename}", UseShellExecute = true });
        }
    }
}
