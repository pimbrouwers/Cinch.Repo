# Dapper.UnitOfWork

> This library is intended to be used **asynchronously** only. Non-async methods are not exposed.

Unit of Work implementation for Dapper. This project relies on [sequel](https://github.com/sequel) for entity mapping and CRUD templating and [lunch-pail](https://github.com/lunch-pail) for establishing the database context.

The intention of this project is to provide an abstract repository to be implemented using an **opt-in** model. Whereby only the desired functionality is exposed to consumers. The dependency on `IDbContext` provides the context to establish the unit of work, and `ISqlMapper<TEntity>` yields the required information about the entity. The opt-in model was chosen as I feel it's favorable to the generic repository approach, insofar that it exposes all functionality to all models, which is rarely desireable.

## Getting Started

1. Implement the desired facets of `AbstractRepository`
```c#
//Post.cs
public class Post 
{
  public int Id { get; set; } //ISqlMapper assumes a key named "Id"
  public string Author { get; set; }
  public string Body { get; set; }
}

//IPostRepository.cs
public interface IPostRepository 
{
  Task<Post> Read (int id);
}

//PostRepository.cs
public class PostRepository : AbstractRepository<Post>, IPostRepository
{
  public PostRepositry(
    IDbContext dbContext,
    ISqlMapper<Post> sqlMapper
  ) : base(dbContext, sqlMapper)
  { }

  public async Task<Post>Read(int id)
  {
    return await ReadEntity(id);
  }
}
```

### Custom Entity Key

Working with the example above, let's assume that your entity's key field is called "PostId" and not "Id". Since `ISqlMapper` will assume a key named "Id" we need to override this property.

```c#
//Post.cs
public class Post 
{
  public int PostId { get; set; }
  ///...
}

//PostSqlMapper.cs
public class PostSqlMapper : ISqlMapper<Post>
{
  public override string Key =>
    "PostId";
}
```

You will of course need to ensure your IoC is creating this when request, as opposed to the generic `SqlMapper<Post>`. But otherwise, no other changes will be necessary.

Built with ♥ by [Pim Brouwers](https://github.com/pimbrouwers) in Toronto, ON. 
