using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cinch.Repo.Interfaces
{
  public interface IMapper<TEntity> where TEntity : class
  {
    IEnumerable<PropertyInfo> Properties { get; }
    Type Type { get; }
  }
}