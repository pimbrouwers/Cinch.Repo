namespace Cinch.Repo
{
    public abstract class BaseRepo
    {
        public readonly IConnectionFactory connectionFactory;

        public BaseRepo(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
