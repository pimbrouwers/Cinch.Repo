namespace Cinch.Repo
{
    public abstract class BaseRepo
    {
        public readonly ISqlConnectionFactory connectionFactory;

        public BaseRepo(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
