namespace Cinch.Repo
{
    public interface IDbService
    {
        ISqlConnectionFactory ConnectionFactory { get; }
    }
}
