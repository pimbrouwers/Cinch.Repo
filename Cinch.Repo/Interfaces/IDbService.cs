namespace Cinch.Repo.Interfaces
{
    public interface IDbService
    {
        ISqlConnectionFactory ConnectionFactory { get; }
    }
}
