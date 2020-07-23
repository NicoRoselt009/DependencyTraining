namespace DependencyContainer
{
    public interface IRepository
    {
        void Update();
        void Delete();
        void Add();
        void Get();
        void SingleOrDefault();
        void Any();
        void First();
        void FirstOrDefault();
        void Where();
        void GroupBy();
    }
}
