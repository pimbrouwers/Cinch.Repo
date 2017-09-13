using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
    public interface ISqlConnectionFactory
    {
        string ConnectionString { get; }
        Task<SqlConnection> CreateConnection();
    }
}
