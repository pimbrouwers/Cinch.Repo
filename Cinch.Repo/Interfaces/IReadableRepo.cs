using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IPaginator
    {
        int n { get; set; }
        string sort { get; set; }
        string order { get; set; }
        object since { get; set; }
    }

    public interface IReadableRepo<TEntity, in TKey> where TEntity : class
    {
        IConnectionFactory ConnectionFactory { get; }

        Task<IEnumerable<TEntity>> List(IPaginator pagination);
        Task<TEntity> Get(TKey id);
        Task<IEnumerable<TEntity>> Query(string sql, object param = null, CommandType commandType = CommandType.Text);
        Task<TEntity> First(string sql, object param = null, CommandType commandType = CommandType.Text);
    }
}
