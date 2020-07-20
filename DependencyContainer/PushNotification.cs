using System;

public interface ISendPushNotifications
{
    void Send(string message);
}

public class OnesignalPushNotificationService : ISendPushNotifications
{
    public void Send(string message)
    {
        Console.WriteLine("Sent with One Signal");
    }
}

public class AtajoPushNotificationService : ISendPushNotifications
{
    public void Send(string message)
    {
        Console.WriteLine("Sent with Atajo");
    }
}
