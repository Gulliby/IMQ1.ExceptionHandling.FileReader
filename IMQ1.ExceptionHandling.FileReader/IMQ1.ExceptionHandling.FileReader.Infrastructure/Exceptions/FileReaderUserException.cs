using System;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Exceptions
{
    public class FileReaderUserException : Exception
    {
        public FileReaderUserException(): this(FileReaderMessages.FileReaderUserExcetion)
        {
        }

        public FileReaderUserException(string message)
            : base(message)
        {
        }

        public FileReaderUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
