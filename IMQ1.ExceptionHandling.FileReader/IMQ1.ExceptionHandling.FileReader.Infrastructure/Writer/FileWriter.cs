using System.IO;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Writer.Interface;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Writer
{
    public class FileWriter : IWriter
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(_filePath, $"{message}\n\r");
        }
    }
}
