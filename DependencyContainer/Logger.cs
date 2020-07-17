using System;

namespace DependencyContainer
{
    public class Logger
    {
        public void LogStart()
        {
            Console.WriteLine("I have been registered mofo.");
        }
    }

    public class AnotherLogger
    {
        public void LogStart()
        {
            Console.WriteLine("I have been registered again mofo.");
        }
    }
}
