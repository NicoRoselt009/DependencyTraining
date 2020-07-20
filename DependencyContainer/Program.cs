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

            var pushNotifications = Application.Container.Resolve<ISendPushNotifications>();
            pushNotifications.Send("This is a working");

            var resolveFirst = Application.Container.Resolve<SingletonExample>();
            resolveFirst.Add(100);
            resolveFirst.Print();

            var resolveSecond = Application.Container.Resolve<SingletonExample>();
            resolveSecond.Add(100);
            resolveSecond.Print();

            Console.ReadLine();
        }

        private static void RegisterDependencies(Container container)
        {
            container.Register<Logger>()
                     .Register<AnotherLogger>()
                     .Register<SingletonExample>()
                     .Register<ISendPushNotifications, OnesignalPushNotificationService>();
        }
    }
}

//TODO: Make this a nuGet package