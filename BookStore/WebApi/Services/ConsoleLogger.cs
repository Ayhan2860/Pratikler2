using System;

namespace WebApi.Sevices
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
           Console.WriteLine("[Console Logger] =>" + message);
        }
    }
}