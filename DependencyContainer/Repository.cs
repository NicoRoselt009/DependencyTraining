namespace DependencyContainer
{
    public class Repository : IRepository
    {
        private readonly IConnectionFactory connectionFactory;

        public Repository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Add()
        {
            
        }

        public void Any()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void First()
        {
            throw new System.NotImplementedException();
        }

        public void FirstOrDefault()
        {
            throw new System.NotImplementedException();
        }

        public void Get()
        {
            throw new System.NotImplementedException();
        }

        public void GroupBy()
        {
            throw new System.NotImplementedException();
        }

        public void SingleOrDefault()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Where()
        {
            throw new System.NotImplementedException();
        }
    }
}
