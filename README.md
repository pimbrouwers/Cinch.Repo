# Cinch.Repo
Repository design pattern implementation for Dapper,.

## Getting Started

The outcome of what's outlined below is to be left with an implementation of `IDbService` for which an implementation of `ISqlConnectionFactory` needs to be injected.

### Implement `IDbConnectionFactory` (`SqlConnection` example below)

```c#
public class SqlConnectionFactory : IDbConnectionFactory
{
  private readonly string connectionString;

  public SqlConnectionFactory(string connectionString)
  {
    if (string.IsNullOrWhiteSpace(connectionString))
    {
      throw new ArgumentNullException("ConnectionString cannot be null");
    }

    this.connectionString = connectionString;
  }

  public async Task<IDbConnection> CreateOpenConnection()
  {
    var conn = new SqlConnection(connectionString);

    try
    {
      if (conn.State != ConnectionState.Open)
        await conn.OpenAsync();
    }
    catch (Exception exception)
    {
      throw new Exception("An error occured while connecting to the database. See innerException for details.", exception);
    }

    return conn;
  }
}
```

### Register Services (`Startup.cs` example below)

```c#
//within ConfigureServices()
services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>(ctx =>
{
  return new SqlConnectionFactory(Configuration.GetConnectionString("DefaultConnection"));
});
services.AddSingleton(typeof(IMapper<>), typeof(Mapper<>));
services.AddScoped(typeof(ITable<>), typeof(Table<>));
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
```

Built with ♥ by [Pim Brouwers](https://github.com/pimbrouwers) in Toronto, ON. 
