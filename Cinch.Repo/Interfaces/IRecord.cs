namespace Cinch.Repo
{
    public interface IRecord<TKey>
    {
        TKey Id { get; set; }
    }
}
