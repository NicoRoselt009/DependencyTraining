namespace DependencyContainer
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
