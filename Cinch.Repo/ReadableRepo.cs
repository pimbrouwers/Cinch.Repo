using Cinch.Repo.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class ReadableRepo<TEntity, TKey> : BaseRepo, IReadableRepo<TEntity, TKey> where TEntity : class
    {
        public readonly string tableName;

        public ReadableRepo(ISqlConnectionFactory connectionFactory) : base(connectionFactory) { }
        
        public virtual async Task<TEntity> Get(TKey id)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAsync<TEntity>(id);
            }
        }
        
    }
}
