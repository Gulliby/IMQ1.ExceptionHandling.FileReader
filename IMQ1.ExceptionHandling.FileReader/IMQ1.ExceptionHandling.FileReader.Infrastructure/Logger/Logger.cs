using System;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Extensions;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Logger.Interface;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Writer.Interface;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Logger
{
    public class Logger : ILogger
    {
        private readonly IWriter _writer;
        
        public Logger(IWriter writer)
        {
            _writer = writer;
        }

        public void Log(string message, Exception exception)
        {
            _writer.Write($"Message: {message}. StackTrace: {exception.StackTrace}. Info: {exception.GetFullMessage()}.");
        }
    }
}
