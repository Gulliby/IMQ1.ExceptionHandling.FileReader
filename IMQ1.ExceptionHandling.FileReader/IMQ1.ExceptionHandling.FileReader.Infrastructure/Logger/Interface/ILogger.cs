using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMQ1.ExceptionHandling.FileReader.Infrastructure.Logger.Interface
{
    public interface ILogger
    {
        void Log(string message, Exception exception);
    }
}
