using System;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Exceptions
{
    public class FileReaderSystemException: SystemException
    {
        public FileReaderSystemException(): this(FileReaderMessages.FileReaderSystemExcetion)
        {
        }

        public FileReaderSystemException(string message)
            : base(message)
        {
        }

        public FileReaderSystemException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
