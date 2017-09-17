using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        /// <summary>
        /// Get Many
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns>Enumerable of TEntity</returns>
        public async Task<IEnumerable<TEntity>> Query(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.QueryAsync<TEntity>(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Get First
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns>TEntity or default(TEntity)</returns>
        public async Task<TEntity> First(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return (await Query(sql, param, commandType)).FirstOrDefault();
        }
    }
}
