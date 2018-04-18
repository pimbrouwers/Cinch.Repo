using System.Data;
using System.Threading.Tasks;

namespace Cinch.Repo.Interfaces
{
  public interface IDbConnectionFactory
  {
    Task<IDbConnection> CreateOpenConnection();
  }
}