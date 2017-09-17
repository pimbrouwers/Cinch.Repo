using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class ReadableRepo<TEntity, TKey> : BaseRepo, IReadableRepo<TEntity, TKey> where TEntity : class
    {
        public ReadableRepo(IConnectionFactory connectionFactory) : base(connectionFactory) { }
        
        public virtual async Task<TEntity> Get(TKey id)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAsync<TEntity>(id);
            }
        }
        
    }
}
