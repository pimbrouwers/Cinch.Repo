using Cinch.Repo.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cinch.Repo
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    public Repository(IDbConnectionFactory connectionFactory, ITable<TEntity> table)
    {
      this.ConnectionFactory = connectionFactory;
      this.Table = table;
    }

    public IDbConnectionFactory ConnectionFactory { get; }

    public ITable<TEntity> Table { get; }

    public async Task<int> Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection conn = null)
    {
      if (conn != null) return await conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
      else if (transaction != null) return await transaction.Connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);

      using (conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
      }
    }

    public async Task<T> ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection conn = null)
    {
      if (conn != null) return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
      else if (transaction != null) return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);

      using (conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
      }
    }

    public async Task<IEnumerable<T>> Query<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync<T>(sql, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync<T>(sql, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync<TEntity>(sql, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync<TEntity>(sql, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      if (transaction != null) return await transaction.Connection.QueryAsync(sql, map, param, transaction, commandType: commandType);

      using (var conn = await ConnectionFactory.CreateOpenConnection())
      {
        return await conn.QueryAsync(sql, map, param, transaction, commandType: commandType);
      }
    }

    public async Task<T> First<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query<T>(sql, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }

    public async Task<TEntity> First<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text)
    {
      return (await Query(sql, map, param, transaction, commandType)).FirstOrDefault();
    }
  }
}