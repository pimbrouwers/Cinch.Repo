﻿using Cinch.Repo.Interfaces;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public abstract class ReadableRepo<TEntity, TKey> : BaseRepo, IReadableRepo<TEntity, TKey> where TEntity : class
    {
        public ReadableRepo(ISqlConnectionFactory connectionFactory) : base(connectionFactory) { }

        public virtual async Task<IEnumerable<TEntity>> List()
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAllAsync<TEntity>();
            }
        }

        public virtual async Task<TEntity> Get(TKey id)
        {
            using (var conn = await connectionFactory.CreateConnection())
            {
                return await conn.GetAsync<TEntity>(id);
            }
        }
    }
}