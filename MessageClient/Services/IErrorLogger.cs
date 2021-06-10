using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageClient.Services
{
    public interface IErrorLogger
    {
        void Log(LogLevel logLevel, Exception ex, string format);
    }
}