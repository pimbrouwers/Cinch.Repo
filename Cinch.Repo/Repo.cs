using Cinch.Repo.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class Repo<TEntity, TKey> : ReadableRepo<TEntity, TKey>, IRepo<TEntity, TKey> where TEntity : class, IRecord<TKey>, new()
    {
        public Repo(ISqlConnectionFactory connectionFactory) : base(connectionFactory) { }

        public virtual async Task<int> Insert(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.InsertAsync(item);
            }
        }

        public virtual async Task<int> Insert(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.InsertAsync(items);
            }
        }

        public virtual async Task<bool> Update(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.UpdateAsync(item);
            }
        }

        public virtual async Task<bool> Update(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.UpdateAsync(items);
            }
        }

        public virtual async Task<bool> Delete(TEntity item)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.DeleteAsync(item);
            }
        }

        public virtual async Task<bool> Delete(IEnumerable<TEntity> items)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.DeleteAsync(items);
            }
        }

        public async Task<int> Execute(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.ExecuteAsync(sql, param, commandType: commandType);
            }
        }

        public async Task<IEnumerable<TEntity>> Query(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.QueryAsync<TEntity>(sql, param, commandType: commandType);
            }
        }

        public async Task<TEntity> First(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return (await Query(sql, param, commandType)).FirstOrDefault();
        }
    }
}
