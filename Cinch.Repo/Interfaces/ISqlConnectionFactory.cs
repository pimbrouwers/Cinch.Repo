using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
    public interface ISqlConnectionFactory
    {
        string ConnectionString { get; set; }
        Task<SqlConnection> CreateConnection();
    }
}
