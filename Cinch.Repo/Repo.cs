using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class Repo<TEntity> : ReadableRepo<TEntity, int>, IRepo<TEntity> where TEntity : class, IRecord<int>, new()
    {
        public Repo(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Numeric Id of record inserted</returns>
        public virtual async Task<int> Insert(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.InsertAsync(item);
            }
        }

        /// <summary>
        /// Insert Many
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Number of records inserted</returns>
        public virtual async Task<int> Insert(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.InsertAsync(items);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if updated, false if not found or not modified</returns>
        public virtual async Task<bool> Update(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.UpdateAsync(item);
            }
        }

        /// <summary>
        /// Update Many
        /// </summary>
        /// <param name="items"></param>
        /// <returns>true if updated, false if not found or not modified</returns>
        public virtual async Task<bool> Update(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.UpdateAsync(items);
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if deleted, false if not found</returns>
        public virtual async Task<bool> Delete(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.DeleteAsync(item);
            }
        }

        /// <summary>
        /// Delete Many
        /// </summary>
        /// <param name="items"></param>
        /// <returns>true if deleted, false if not found</returns>
        public virtual async Task<bool> Delete(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.DeleteAsync(items);
            }
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns>Number of rows affected</returns>
        public async Task<int> Execute(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.ExecuteAsync(sql, param, commandType: commandType);
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
