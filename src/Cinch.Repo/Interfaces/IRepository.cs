using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
    IDbConnectionFactory ConnectionFactory { get; }

    ITable<TEntity> Table { get; }

    Task<int> Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection conn = null);

    Task<T> ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection conn = null);

    Task<IEnumerable<T>> Query<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<IEnumerable<TEntity>> Query<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<T> First<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First(string sql, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond>(string sql, Func<TEntity, TSecond, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond, TThird>(string sql, Func<TEntity, TSecond, TThird, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond, TThird, TFourth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond, TThird, TFourth, TFifth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond, TThird, TFourth, TFifth, TSixth>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);

    Task<TEntity> First<TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string sql, Func<TEntity, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> map, object param = null, IDbTransaction transaction = null, CommandType commandType = CommandType.Text);
  }
}