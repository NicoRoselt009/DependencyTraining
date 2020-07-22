namespace DependencyContainer
{
    public class AddCommand : ICommand
    {
        private readonly Calculator calculator;
        private readonly int value;

        public AddCommand()
        {
        }

        public AddCommand(Calculator calculator, int value)
        {
            this.calculator = calculator;
            this.value = value;
        }

        public void Exucute()
        {
            calculator.Add(value);
        }

        public void Undo()
        {
            calculator.Subtract(value);
        }

    }
}
