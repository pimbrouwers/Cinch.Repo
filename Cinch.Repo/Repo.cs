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
    }

    public static class RepoExtensons
    {
        public async static Task<int> Execute<TEntity, TKey>(this Repo<TEntity, TKey> repo, string sql, object param, CommandType commandType = CommandType.Text) where TEntity : class, IRecord<TKey>, new()
        {
            using (var conn = await repo.connectionFactory.CreateConnection())
            {
                return await conn.ExecuteAsync(sql, param, commandType: commandType);
            }
        }

        public async static Task<IEnumerable<TEntity>> Query<TEntity, TKey>(this Repo<TEntity, TKey> repo, string sql, object param, CommandType commandType = CommandType.Text) where TEntity : class, IRecord<TKey>, new()
        {
            using (var conn = await repo.connectionFactory.CreateConnection())
            {
                return await conn.QueryAsync<TEntity>(sql, param, commandType: commandType);
            }
        }

        public async static Task<TEntity> First<TEntity, TKey>(this Repo<TEntity, TKey> repo, string sql, object param, CommandType commandType = CommandType.Text) where TEntity : class, IRecord<TKey>, new()
        {
            return (await repo.Query<TEntity, TKey>(sql, param, commandType)).FirstOrDefault();
        }
    }
}
