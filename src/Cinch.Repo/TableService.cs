using Cinch.Repo.Interfaces;
using Cinch.SqlBuilder;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cinch.Repo
{
  public class TableService<TEntity> : ITableService<TEntity> where TEntity : class
  {
    public TableService(
      IRepository<TEntity> repository,
      ITable<TEntity> table)
    {
      Repository = repository;
      Table = table;
    }

    public IRepository<TEntity> Repository { get; }

    public ITable<TEntity> Table { get; }

    public virtual ISqlBuilder GetSql
    {
      get
      {
        return new SqlBuilder.SqlBuilder()
        .Select(Table.Fields)
        .From(Table.Name);
      }
    }

    public virtual ISqlBuilder CreateSql
    {
      get
      {
        return new SqlBuilder.SqlBuilder()
        .Insert(Table.Name)
        .Columns(Table.NonKeyFields)
        .Values(string.Join(",", Table.NonKeyFields.Select(f => $"@{f}")));
      }
    }

    public virtual ISqlBuilder UpdateSql
    {
      get
      {
        return new SqlBuilder.SqlBuilder()
        .Update(Table.Name)
        .Set(Table.NonKeyFields.Select(f => $"{f} = @{f}").ToArray())
        .Where($"{Table.Key} = @{Table.Key}");
      }
    }

    public virtual ISqlBuilder DeleteSql
    {
      get
      {
        return new SqlBuilder.SqlBuilder()
        .Delete()
        .From(Table.Name)
        .Where($"{Table.Key} = @{Table.Key}");
      }
    }

    public virtual async Task<int> Create(TEntity entity, IDbTransaction transaction = null)
    {
      var sql = $"{CreateSql.ToSql()}; {new SqlBuilder.SqlBuilder().Select(Table.Key).From(Table.Name).Where($"{Table.Key} = scope_identity()").ToSql()};";
      return await Repository.First<int>(sql, entity, transaction);
    }

    public virtual async Task<bool> Delete(TEntity entity, IDbTransaction transaction = null)
    {
      int rowsAffected = await Repository.Execute(DeleteSql.ToSql(), entity, transaction);

      return rowsAffected == 1;
    }

    public virtual async Task<IEnumerable<TEntity>> Find(string field, object value)
    {
      return await Repository.Query(GetSql.Where($"{field} = @value").ToSql(), new { value });
    }

    public virtual async Task<TEntity> FindFirst(string field, object value)
    {
      return (await Repository.Query(GetSql.Where($"{field} = @value").ToSql(), new { value })).FirstOrDefault();
    }

    public virtual async Task<IEnumerable<TEntity>> List()
    {
      return await Repository.Query(GetSql.ToSql());
    }

    public virtual async Task<TEntity> Read(object key)
    {
      return await FindFirst(Table.Key, key);
    }

    public virtual async Task<bool> Update(TEntity entity, IDbTransaction transaction = null)
    {
      int rowsAffected = await Repository.Execute(UpdateSql.ToSql(), entity, transaction);

      return rowsAffected == 1;
    }
  }
}