using System;
using System.Collections.Generic;

namespace DependencyContainer
{
    public class CalculatorService
    {
        private Stack<ICommand> undoList = new Stack<ICommand>();

        private readonly Calculator calculator;

        public CalculatorService(string test)
        {
            calculator = new Calculator();
        }

        public void Execute(AddCommand command)
        {
            calculator.Add(command.Value);
            undoList.Push(command);
        }

        public void Execute(SubtractCommand command)
        {
            calculator.Subtract(command.Value);
            undoList.Push(command);
        }

        public void Undo()
        {
            dynamic command = undoList.Pop();
            Undo(command);
        }

        public void Print()
        {
            calculator.Print();
        }

        private void Undo(AddCommand command)
        {
            calculator.Subtract(command.Value);
        }

        private void Undo(SubtractCommand command)
        {
            calculator.Add(command.Value);
        }
    }
}
