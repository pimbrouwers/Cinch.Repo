using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IReadableRepo<TEntity, in TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> List(int n, string sort, string order, object max = null, object min = null);
        Task<TEntity> Get(TKey id);
    }
}
