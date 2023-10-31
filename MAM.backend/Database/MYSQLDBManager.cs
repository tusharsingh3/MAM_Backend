using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Input;

namespace MAM.backend.Database
{
    public class MYSQLDBManager : DBManager
    {
        public MYSQLDBManager()
        {
        }
        public override DBManager GetDBManager(string connectionstring)
        {
            _connectionString = connectionstring;
            DBManager dbManager = new MYSQLDBManager();
            return dbManager;

        }
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public override IDbCommand CreateCommand(string query)
        {
            return new MySqlCommand(query);
        }

        public override IDbDataAdapter CreateDataAdapter(IDbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }
    }
}
