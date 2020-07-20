﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Container
{
    private static List<Dependency> listOfTypes;
    private static readonly Guid instanceId;

    static Container()
    {
        listOfTypes = new List<Dependency>();
        instanceId = Guid.NewGuid();
    }

    public Container Register<T>(LifetimeScope lifetimeScope = LifetimeScope.InstancePerDependency) where T : class
    {
        var dependency = new Dependency();
        dependency.Register<T>(lifetimeScope, instanceId);
        listOfTypes.Add(dependency);

        return this;
    }

    public Container Register<TInterface, TClass>(LifetimeScope lifetimeScope = LifetimeScope.InstancePerDependency) where TClass : class
    {
        var dependency = new Dependency();
        dependency.Register<TInterface, TClass>(lifetimeScope, instanceId);
        listOfTypes.Add(dependency);

        return this;
    }

    public T Resolve<T>() where T : class
    {
        var result = listOfTypes.SingleOrDefault(x => x.Resolve<T>());

        if (result == null)
            throw new NotImplementedException("Type has not been implemented");

        switch (result.lifetimeScope)
        {
            case LifetimeScope.SingleInstance:
                return BuildSingleInstance<T>(result);
            case LifetimeScope.InstancePerDependency:
                return (T)Activator.CreateInstance(result.ConcreteType);
            case LifetimeScope.InstancePerLifetimeScope:
                return BuildInstancePerLifetimeScope<T>(result);
            default:
                return (T)Activator.CreateInstance(result.ConcreteType);
        }
    }

    private static T BuildSingleInstance<T>(Dependency result) where T : class
    {
        if (result.ActivatedInstance != null)
            return (T)result.ActivatedInstance;
        else
        {
            var activatedInstance = (T)Activator.CreateInstance(result.ConcreteType);
            result.ActivatedInstance = activatedInstance;
            return activatedInstance;
        }
    }

    private static T BuildInstancePerLifetimeScope<T>(Dependency result) where T : class
    {
        if (result.InstanceId == instanceId && result.ActivatedInstance != null)
            return (T)result.ActivatedInstance;
        else
        {
            var activatedInstance = (T)Activator.CreateInstance(result.ConcreteType);
            result.ActivatedInstance = activatedInstance;
            return activatedInstance;
        }
    }
}
