using System;
using System.Collections.Generic;
using System.Linq;

public class Container
{
    private static List<Type> listOfTypes;

    static Container()
    {
        listOfTypes = new List<Type>();
    }

    public Container Register<T>() where T : class
    {
        listOfTypes.Add(typeof(T));

        return this;
    }

    public T Resolve<T>() where T : class
    {
        var resultType = listOfTypes.SingleOrDefault(x => x == typeof(T));

        if (resultType == null)
            throw new NotImplementedException("Type has not been implemented");

        return (T)Activator.CreateInstance(resultType);
    }
}
