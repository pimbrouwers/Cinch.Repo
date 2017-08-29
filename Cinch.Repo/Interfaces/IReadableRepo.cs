using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
    public interface IReadableRepo<TEntity, in TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> List();
        Task<TEntity> Get(TKey id);
    }
}
