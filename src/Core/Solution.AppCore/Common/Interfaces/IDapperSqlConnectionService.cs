using System.Data;

namespace PdsCleanAppCore.Common.Interfaces
{
    public interface IDapperSqlConnectionService
    {
        IDbConnection GetDapperConnection();
    }
}
