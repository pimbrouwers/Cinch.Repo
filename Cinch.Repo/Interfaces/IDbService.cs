namespace Cinch.Repo
{
    public interface IDbService
    {
        IConnectionFactory ConnectionFactory { get; }
    }
}
