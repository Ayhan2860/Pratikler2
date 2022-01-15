using System;

namespace WebApi.Sevices
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[Database Logger] =>" + message);
        }
    }
}