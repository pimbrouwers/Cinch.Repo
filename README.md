# Cinch.Repo
Repository design pattern implementation for Dapper, for usage with **SQL Server**.

## Getting Started

The outcome of what's outlined below is to be left with an implementation of `IDbService` for which an implementation of `ISqlConnectionFactory` needs to be injected.

### 1. Implement `IDbService`

```c#
public interface IMyDbService : IDbService
{
	ISqlConnectionFactory ConnectionFactory { get; }
    ISomeRepo SomeRepo { get; }
}

public class MyDbService : IMyDbService 
{
	readonly ISqlConnectionFactory connectionFactory;
	ISomeRepo someRepo;
	
	public MyDbService (ISqlConnectionFactory connectionFactory)
	{
		this.connectionFactory = connectionFactory;
	}
	
	public ISomeRepo 
	{
		get
		{
			if(someRepo == null)
			{
				someRepo = new SomeRepo(connectionFactory);
			}
			
			return someRepo;
		}
	}
}
```

### 2. Implement `IRepo`

```c#
public interface ISomeRepo : IRepo<SomeModel, int> {}

public sealed class SomeRepo : Repo<SomeModel, int>, ISomeRepo 
{
	public SomeRepo(ISqlConnectionFactory connectionFactory) : base(connectionFactory) {}
}
```

### 3. Implement `IRecord`

```c#
public interface ISomeModel : IRecord<int>
{
	string SomeField { get; set; }
}

public class SomeModel : Record<int>, ISomeModel
{
	public string SomeField { get; set; }
}
```

### 4. Implementation `ISqlConnectionFactory`

```c#
public SqlConnectionFactory : ISqlConnectionFactory 
{
	readonly string connectionString;
	
	public SqlConnectionFactory(string connectionString)
	{
		this.connectionString = connectionString;
	}
	
	public string ConnectionString
	{
		get
		{
			if(string.IsNullOrWhiteSpace(connectionString) throw new ArgumentNullException("ConnectionString cannot be null");
			return connectionString;
		}
	}
	
	public async Task<SqlConnection> CreateConnection()
	{
		var conn = new SqlConnection(connectionString);
		
		try
	    {
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

Built with ♥ by [Pim Brouwers](https://github.com/pimbrouwers) in Toronto, ON. 