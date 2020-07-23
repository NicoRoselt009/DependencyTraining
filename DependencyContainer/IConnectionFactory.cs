using System;

public interface IConnectionFactory 
{
    string BuildConnectionString();
    void Initialize();
}


public abstract class ConnectionFactoryBase : IConnectionFactory
{
    private string connectionString;

    public string BuildConnectionString()
    {
        return connectionString;
    }

    public void Initialize()
    {
        connectionString = Environment.GetEnvironmentVariable("ConnectionString");
    }
}