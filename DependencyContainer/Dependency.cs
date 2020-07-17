using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyContainer
{
    public static class Dependency
    {
        private static List<Type> listOfTypes;

        static Dependency()
        {
            listOfTypes = new List<Type>();
        }

        public static void Register<T>() where T : class
        {
            listOfTypes.Add(typeof(T));
        }

        public static T Resolve<T>() where T : class
        {
            var resultType = listOfTypes.SingleOrDefault(x => x == typeof(T));
            if (resultType == null) throw new NotImplementedException("Type has not been implemented");
            return (T)Activator.CreateInstance(resultType);
        }
    }
}
