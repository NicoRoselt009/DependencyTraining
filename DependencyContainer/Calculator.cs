using System;

namespace DependencyContainer
{
    public class Calculator
    {
        private int value;

        public Calculator Add(int number)
        {
            value += number;
            return this;
        }

        public Calculator Subtract(int number)
        {
            value -= number;
            return this;
        }

        public void Print()
        {
            Console.WriteLine(value);
        }
    }
}
