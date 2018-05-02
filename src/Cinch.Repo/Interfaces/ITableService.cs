using Cinch.SqlBuilder;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
  public interface ITableService<TEntity> where TEntity : class
  {
    IRepository<TEntity> Repository { get; }

    ITable<TEntity> Table { get; }

    ISqlBuilder GetSql { get; }

    ISqlBuilder CreateSql { get; }

    ISqlBuilder UpdateSql { get; }

    ISqlBuilder DeleteSql { get; }

    Task<int> Create(TEntity entity, IDbTransaction transaction = null);

    Task<bool> Delete(TEntity entity, IDbTransaction transaction = null);

    Task<IEnumerable<TEntity>> Find(string field, object value);

    Task<TEntity> FindFirst(string field, object value);

    Task<IEnumerable<TEntity>> List();

    Task<TEntity> Read(object key);

    Task<bool> Update(TEntity entity, IDbTransaction transaction = null);
  }
}