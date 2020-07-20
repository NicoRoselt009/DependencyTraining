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

            var calculator = new Calculator();

            calculator.Add(5)
                      .Add(15)
                      .Add(30)
                      .Subtract(5)
                      .Print();

            Console.ReadLine();
        }

        private static void RegisterDependencies(Container container)
        {
            container.Register<Logger>()
                     .Register<AnotherLogger>()
                     .Register<ISendPushNotifications, OnesignalPushNotificationService>();
        }
    }
}

//TODO: Make this a nuGet package