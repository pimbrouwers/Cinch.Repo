using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IRepo<TEntity> : IReadableRepo<TEntity, int> where TEntity : class, IRecord<int>, new()
    {
        Task<int> Insert(TEntity item);
        Task<int> Insert(IEnumerable<TEntity> items);
        Task<bool> Update(TEntity item);
        Task<bool> Update(IEnumerable<TEntity> items);
        Task<bool> Delete(TEntity item);
        Task<bool> Delete(IEnumerable<TEntity> items);
    }
}
