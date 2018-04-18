namespace Cinch.Repo.Interfaces
{
  public interface ITable<TEntity> where TEntity : class
  {
    IMapper<TEntity> Mapper { get; }
    string[] Fields { get; }
    string[] FieldsQualified { get; }
    string Key { get; }
    string[] NonKeyFields { get; }
    string[] NonKeyFieldsQualified { get; }
    string Name { get; }
  }
}