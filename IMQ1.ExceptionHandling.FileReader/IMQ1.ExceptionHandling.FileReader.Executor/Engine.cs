using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMQ1.ExceptionHandling.FileReader.Infrastructure.Exceptions;

namespace IMQ1.ExceptionHandling.FileReader.Executor
{
    class Engine
    {
        static void Main(string[] args)
        {
            string filePath;

            Console.Write("FilePath = ");
            filePath = Console.ReadLine();

            uint startPosition = 0;
            Console.Write("StartPosition");
            if (!uint.TryParse(Console.ReadLine(), out startPosition))
            {
                Console.WriteLine("This argument is not supported. Try later. :)");
                return;
            }

            ulong length = 0;
            Console.Write("StartPosition");
            if (!ulong.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine("This argument is not supported. Try later. :)");
                return;
            }

            var reader = new Library.FileReader();

            var exceptionthrown = false;
            do
            {
                try
                {
                    Console.WriteLine(reader.Read(filePath, startPosition, length));
                    exceptionthrown = false;
                }
                catch (FileReaderSystemException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionthrown = true;
                }
                catch (FileIsNotExistFileReaderException ex)
                {
                    Console.WriteLine("Chouse anouther one file.");
                    Console.WriteLine(ex.Message);
                }
                catch (FileReaderUserException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (exceptionthrown);
            Console.ReadKey();
        }
    }
}
