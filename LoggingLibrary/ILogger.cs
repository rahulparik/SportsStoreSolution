using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public interface ILogger
    {
        void LogInformation(string componentName, string method, TimeSpan timeSpan, string properties);
    }
}
