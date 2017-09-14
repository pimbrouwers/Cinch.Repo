using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class ReadableRepo<TEntity, TKey> : BaseRepo, IReadableRepo<TEntity, TKey> where TEntity : class
    {
        public ReadableRepo(ISqlConnectionFactory connectionFactory) : base(connectionFactory) { }
        
        public virtual async Task<TEntity> Get(TKey id)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAsync<TEntity>(id);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> List(int page = 1, int pagesize = 30)
        {
            if (pagesize > 100) pagesize = 100;

            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAllAsync<TEntity>();
            }
        }
    }
}
