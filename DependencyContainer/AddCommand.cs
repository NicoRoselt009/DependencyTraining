namespace DependencyContainer
{
    public class AddCommand : ICommand
    {
        public int Value { get; }

        public AddCommand(int value)
        {
            Value = value;
        }

    }
}
