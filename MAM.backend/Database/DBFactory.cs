using System;
using System.Collections.Generic;

namespace MAM.backend.Database
{
	public class DBFactory
	{
		private static Dictionary<string, DBManager> _dbManagers = null;

		static DBFactory()
		{
			_dbManagers = new Dictionary<string, DBManager>
			{
				{ "mssql", new MSSQLDBManager() },
				{ "mysql", new MYSQLDBManager() }
			};
		}

		public Tuple<DBManager, bool> CreateDatabase(string databaseType, string connectionString)
		{

			DBManager dbmanager = null;
			bool isValid = false;

			if (_dbManagers != null)
			{
				if (_dbManagers.ContainsKey(databaseType))
				{
					dbmanager = _dbManagers[databaseType];
					if (dbmanager != null)
					{
						dbmanager = dbmanager.GetDBManager(connectionString);
						isValid = dbmanager.VerifyConnection();
					}
				}
			}
			Tuple<DBManager, bool> result = new Tuple<DBManager, bool>(dbmanager, isValid);
			return result;
		}
	}
}
