using Dapper.Contrib.Extensions;

namespace Cinch.Repo
{
    public abstract class Record<TKey> : IRecord<TKey>
    {
        public Record() { }
        public Record(TKey id)
        {
            this.Id = id;
        }

        [Key]
        public TKey Id { get; set; }
    }
}
