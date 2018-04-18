using Cinch.Repo.Interfaces;
using System;
using System.Linq;

namespace Cinch.Repo
{
  public class Table<TEntity> : ITable<TEntity> where TEntity : class
  {
    private IMapper<TEntity> mapper;
    private string name;
    private string[] fields;
    private string[] nonKeyFields;

    public Table(IMapper<TEntity> mapper)
    {
      this.mapper = mapper;
    }

    public IMapper<TEntity> Mapper => mapper;

    public string Name
    {
      get
      {
        if (string.IsNullOrWhiteSpace(name))
        {
          name = mapper.Type.Name;
        }

        return name;
      }
    }

    public string Key => "Id";

    public string[] Fields
    {
      get
      {
        if (fields == null)
        {
          fields = mapper.Properties.Select(m => m.Name).ToArray();
        }

        return fields;
      }
    }

    public string[] FieldsQualified
    {
      get
      {
        return Fields.Select(f => $"{Name}.{f}").ToArray();
      }
    }

    public string[] NonKeyFields
    {
      get
      {
        if (nonKeyFields == null)
        {
          nonKeyFields = Fields.Where(f => !string.Equals(f, Key, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        return nonKeyFields;
      }
    }

    public string[] NonKeyFieldsQualified
    {
      get
      {
        return NonKeyFields.Select(f => $"{Name}.{f}").ToArray();
      }
    }
  }
}