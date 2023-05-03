using System.Data.SqlClient;

namespace DeeplHelperDb
{
    public class DbContext
    {

        private readonly string sqlString;
        public DbContext(string _sqlString) {
            sqlString = _sqlString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(sqlString);
        }
    }
}
