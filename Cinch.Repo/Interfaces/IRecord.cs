namespace Cinch.Repo.Interfaces
{
    public interface IRecord<TKey>
    {
        TKey Id { get; set; }
    }
}
