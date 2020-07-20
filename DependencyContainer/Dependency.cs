using System;

public enum LifetimeScope
{
    InstancePerDependency,
    SingleInstance
}

public class Dependency
{
    public Type InterfaceType { get; private set; }
    public Type ConcreteType { get; private set; }
    public object ActivatedInstance { get; internal set; }

    private bool IsInterfaceRegistration;

    public LifetimeScope lifetimeScope { get; private set; }

    public Dependency Register<T>(LifetimeScope lifetimeScope) where T : class
    {
        ConcreteType = typeof(T);

        IsInterfaceRegistration = false;
        this.lifetimeScope = lifetimeScope;

        return this;
    }

    public Dependency Register<TInterface, TClass>(LifetimeScope lifetimeScope) where TClass : class
    {
        this.InterfaceType = typeof(TInterface);
        this.ConcreteType = typeof(TClass);

        IsInterfaceRegistration = true;
        this.lifetimeScope = lifetimeScope;

        return this;
    }

    public bool Resolve<TClass>() where TClass : class
    {
        var isInterface = typeof(TClass).IsInterface;

        if (isInterface)
            return this.IsInterfaceRegistration && typeof(TClass) == InterfaceType;
        else
            return !this.IsInterfaceRegistration && typeof(TClass) == ConcreteType;
    }
}
