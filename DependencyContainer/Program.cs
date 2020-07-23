using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyContainer
{
    class Program
    {
        private static Dictionary<Type, dynamic> commandRegistrar;

        static void Main(string[] args)
        {
            RegisterDependencies(Application.Container);




            //RegisterDependencies(Application.Container);
            //var calculatorService = Application.Container.Resolve<CalculatorService>();

            //RegisterCommands(calculatorService);

            //Execute<AddCommand>(new AddCommand(20));
            // Execute<SubtractCommand>(new SubtractCommand(20));

            // Console.ReadLine();
        }

        private static void RegisterCommands(CalculatorService calculatorService)
        {
            commandRegistrar = new Dictionary<Type, dynamic>();
            commandRegistrar.Add(typeof(AddCommand), calculatorService);
            commandRegistrar.Add(typeof(SubtractCommand), calculatorService);
        }

        private static void Execute<T>(ICommand command)
        {
            var dispatcher = commandRegistrar.Single(x => x.Key == command.GetType());

            dispatcher.Value.Execute((T)command);
        }

        private static void RegisterDependencies(Container container)
        {
            container.Register<Logger>()
                     .Register<AnotherLogger>()
                     .Register<ISendPushNotifications, OnesignalPushNotificationService>()
                     .Register<CalculatorService>();
        }
    }
}

//TODO: Make this a nuGet package