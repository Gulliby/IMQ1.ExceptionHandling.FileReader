using System;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Logger.Interface;
using System.Collections.Generic;
using System.IO;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Exceptions;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Logger;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Writer;

namespace IMQ1.ExceptionHandling.FileReader.Library
{
    public class FileReader
    {
        private HashSet<string> _extensions = new HashSet<string> { ".txt" };

        // Should be aspect or so. May be DI. (><)
        private readonly ILogger _logger;

        public FileReader() : this(new Logger(new FileWriter("fileReader.log")))
        {
        }

        public FileReader(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Reads the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public string Read(string filePath, uint? startPosition = null, ulong? length = null)
        {
            // How Should I test my method WITH THIS.....?

            var random = new Random();

            if (random.Next(10) <= 3)
            {
                throw new FileReaderSystemException("FileReader is busy!");
            }

            if (!File.Exists(filePath))
            {
                throw new FileIsNotExistFileReaderException($"File {filePath} is no exist!");
            }

            byte[] result;
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var exMessage =
                        $"FileReader can't read file with current parameters: StartPosition = {startPosition}, Length = {length}.";
                    
                    // Can be removed.
                    if (startPosition == null)
                        startPosition = 0;

                    if (length != null
                        && (fs.Length - startPosition <= 0 || fs.Length < (long) length ||
                            fs.Length - startPosition < (long) length))
                    {
                        var frue = new FileReaderUserException(exMessage);
                        _logger.Log(exMessage, frue);

                        // Something strage.
                        throw frue;
                    }

                    long readLength = 0;
                    if (startPosition != null)
                    {
                        fs.Seek(startPosition.Value, SeekOrigin.Begin);
                        readLength = length == null ? fs.Length - startPosition.Value : (long) length;
                    }

                    result = new byte[readLength];
                    try
                    {
                        fs.Read(result, 0, (int) readLength);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        _logger.Log(exMessage, ex);
                        throw new FileReaderUserException($"Exception : {ex.Message}, Message : {exMessage}.");
                    }
                }
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                var message = $"File {filePath} is unavailable.";
                _logger.Log(message, ex);
                throw new FileReaderSystemException($"Exception : {ex.Message}, Message : {message}.");
            }
            return System.Text.Encoding.UTF8.GetString(result);
        }
    }
}
