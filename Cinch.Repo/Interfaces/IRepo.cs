using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IRepo<TEntity, in TKey> : IReadableRepo<TEntity, TKey> where TEntity : class, IRecord<TKey>, new()
    {
        Task<int> Insert(TEntity item);
        Task<int> Insert(IEnumerable<TEntity> items);
        Task<bool> Update(TEntity item);
        Task<bool> Update(IEnumerable<TEntity> items);
        Task<bool> Delete(TEntity item);
        Task<bool> Delete(IEnumerable<TEntity> items);
    }
}
