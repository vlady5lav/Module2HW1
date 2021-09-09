using System;
using System.IO;

namespace TestLogger
{
    public class FileService
    {
        public void WriteToFile(string path, string log)
        {
            File.WriteAllText(path, log);
        }

        public string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
