using System.Data;
using System.Threading.Tasks;

namespace Cinch.Repo
{
    public interface IConnectionFactory
    {
        string ConnectionString { get; }
        Task<IDbConnection> CreateConnection();
    }
}
