using System;
using System.Collections.Generic;
using System.Linq;

public class Container
{
    private static List<Dependency> listOfTypes;

    static Container()
    {
        listOfTypes = new List<Dependency>();
    }

    public Container Register<T>() where T : class
    {
        var dependency = new Dependency();
        dependency.Register<T>();
        listOfTypes.Add(dependency);

        return this;
    }

    public Container Register<TInterface, TClass>() where TClass : class
    {
        var dependency = new Dependency();
        dependency.Register<TInterface, TClass>();
        listOfTypes.Add(dependency);

        return this;
    }

    public T Resolve<T>() where T : class
    {
        var resultType = listOfTypes.SingleOrDefault(x => x.Resolve<T>());

        if (resultType == null)
            throw new NotImplementedException("Type has not been implemented");

        return (T)Activator.CreateInstance(resultType.ConcreteType);
    }
}
