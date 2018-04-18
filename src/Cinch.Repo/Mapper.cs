using Cinch.Repo.Attributes;
using Cinch.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cinch.Repo
{
  public class Mapper<TEntity> : IMapper<TEntity> where TEntity : class
  {
    private IDictionary<string, Func<TEntity, object>> getters;
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
            && p.GetCustomAttribute<ComputedAttribute>() == null
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

    private IDictionary<string, Func<TEntity, object>> Getters
    {
      get
      {
        if (getters == null)
        {
          getters = Properties.ToDictionary(property => property.Name, property => CreateGetFuncForProperty(property));
        }

        return getters;
      }
    }

    public Dictionary<string, object> ReadPropertyValues(TEntity obj, IEnumerable<string> properties)
    {
      return properties.ToDictionary(property => property, property => Getters[property](obj));
    }

    private Func<TEntity, object> CreateGetFuncForProperty(PropertyInfo property)
    {
      ParameterExpression parameter = Expression.Parameter(type);
      MemberExpression member = Expression.Property(parameter, property);
      UnaryExpression convert = Expression.Convert(member, typeof(object));
      LambdaExpression lambda = Expression.Lambda(typeof(Func<TEntity, object>), convert, parameter);

      return (Func<TEntity, object>)lambda.Compile();
    }
  }
}