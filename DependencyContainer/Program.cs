using System;

namespace DependencyContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterDependencies(Application.Container);

            var calculator = new Calculator();

            var command = new AddCommand(calculator, 20);

            // var logger = Application.Container.Resolve<Logger>();
            // logger.LogStart();

            // var pushNotifications = Application.Container.Resolve<ISendPushNotifications>();
            // pushNotifications.Send("This is a working");

            command.Exucute();

            calculator.Print();

            command.Undo();
            calculator.Print();
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