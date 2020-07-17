using System;

namespace DependencyContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterDependencies(Application.Container);

            var logger = Application.Container.Resolve<Logger>();
            logger.LogStart();

            Console.ReadLine();
        }

        private static void RegisterDependencies(Container container)
        {
            container.Register<Logger>()
                     .Register<AnotherLogger>();
        }
    }
}

//TODO: Make this a nuGet package