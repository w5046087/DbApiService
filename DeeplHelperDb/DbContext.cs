using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace DpApiServer.DbHelper
{
    public class DbContext
    {
        private readonly string _connectionString;
        public DbContext(string?
             connString)
        {

            _connectionString = connString;
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
