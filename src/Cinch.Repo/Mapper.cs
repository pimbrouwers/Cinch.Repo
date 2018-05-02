using Cinch.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cinch.Repo
{
  public class Mapper<TEntity> : IMapper<TEntity> where TEntity : class
  {
    private IEnumerable<PropertyInfo> properties;
    private Type type;

    public IEnumerable<PropertyInfo> Properties
    {
      get
      {
        if (properties == null)
        {
          properties = Type.GetProperties().Where(p =>
            p.CanWrite
            && p.PropertyType.IsPublic
            && string.Equals(p.PropertyType.Namespace, "system", StringComparison.OrdinalIgnoreCase)
            && !typeof(ICollection<>).IsAssignableFrom(p.PropertyType)
          );
        }

        return properties;
      }
    }

    public Type Type
    {
      get
      {
        if (type == null)
        {
          type = typeof(TEntity);
        }
        return type;
      }
    }
  }
}