using System;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Exceptions
{
    public class FileIsNotExistFileReaderException: FileReaderUserException
    {
        public FileIsNotExistFileReaderException(): this(FileReaderMessages.FileReaderFileIsNotExistMessage)
        {
        }

        public FileIsNotExistFileReaderException(string message)
            : base(message)
        {
        }

        public FileIsNotExistFileReaderException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
