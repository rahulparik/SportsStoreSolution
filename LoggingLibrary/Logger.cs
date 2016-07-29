using System;
using System.Diagnostics;

namespace LoggingLibrary
{
    public class Logger : ILogger
    {
        #region ILogger Members
        public void LogInformation(string componentName, string method, TimeSpan timeSpan, string properties)
        {
            string message = string.Concat("Component: ", componentName, "; Method: ", method, ";\nTimeSpan: ", timeSpan.ToString(), "; Properties: ", properties);
            Trace.WriteLine(message);
            Debug.WriteLine(message);
        }

        #endregion
    }
}
