using System;

public class Dependency
{
    public Type InterfaceType { get; private set; }
    public Type ConcreteType { get; private set; }

    private bool IsInterfaceRegistration;

    public void Register<T>() where T : class
    {
        ConcreteType = typeof(T);

        IsInterfaceRegistration = false;
    }

    public void Register<TInterface, TClass>() where TClass : class
    {
        this.InterfaceType = typeof(TInterface);
        this.ConcreteType = typeof(TClass);

        IsInterfaceRegistration = true;
    }

    public bool Resolve<TClass>() where TClass : class
    {
        var isInterface = typeof(TClass).IsInterface;

        if (isInterface)
            return this.IsInterfaceRegistration && typeof(TClass) == InterfaceType;
        else
            return !this.IsInterfaceRegistration && typeof(TClass) == ConcreteType;
    }

    public bool Resolve<TClass, TInterface>() where TInterface : class
    {
        return this.IsInterfaceRegistration && typeof(TInterface) == InterfaceType;
    }
}
