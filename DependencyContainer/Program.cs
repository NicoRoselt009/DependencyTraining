using System;

namespace DependencyContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dependency.Register<Logger>();
            var logger = Dependency.Resolve<Logger>();
            logger.LogStart();
            Console.ReadLine();
        }
    }
}

//TODO: Make this a nuGet package