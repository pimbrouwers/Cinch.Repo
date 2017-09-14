using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IReadableRepo<TEntity, in TKey> where TEntity : class
    {        
        Task<TEntity> Get(TKey id);
        Task<IEnumerable<TEntity>> List(int page, int pagesize);
    }
}
