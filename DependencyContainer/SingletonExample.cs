using System;

public class SingletonExample
{
    private int value;

    public void Add(int number)
    {
        value += number;
    }

    public void Print()
    {
        Console.WriteLine(value);
    }
}