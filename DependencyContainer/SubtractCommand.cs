namespace DependencyContainer
{
    public class SubtractCommand : ICommand
    {
        public SubtractCommand(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
