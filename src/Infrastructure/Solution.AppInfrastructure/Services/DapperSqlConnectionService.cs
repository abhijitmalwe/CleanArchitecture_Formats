using Microsoft.Data.SqlClient;
using PdsCleanAppCore.Common.Interfaces;
using System.Data;

namespace PdsCleanAppInfrastructure.Services
{
    public class DapperSqlConnectionService : IDapperSqlConnectionService
    {
        private readonly string _connectionString;
        public DapperSqlConnectionService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetDapperConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
