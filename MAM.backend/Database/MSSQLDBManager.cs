using System.Data;
using System.Data.SqlClient;

namespace MAM.backend.Database
{
	public class MSSQLDBManager : DBManager
	{

		public MSSQLDBManager()
		{
		}

		public override DBManager GetDBManager(string connectionstring)
		{
			_connectionString = connectionstring;
			DBManager dbManager = new MSSQLDBManager();
			return dbManager;

		}
		public override IDbConnection CreateConnection()
		{
			//_connectionString = connectionstring;
			return new SqlConnection(_connectionString);
		}

		public override IDbCommand CreateCommand(string query)
		{
			return new SqlCommand(query);
		}

		public override IDbDataAdapter CreateDataAdapter(IDbCommand command)
		{
			return new SqlDataAdapter((SqlCommand)command);
		}
	}
}
