using System.Data;

namespace MAM.backend.Database
{
	public abstract class DBManager
	{
		protected static string _connectionString;
		public abstract DBManager GetDBManager(string connectionstring);

		public abstract IDbCommand CreateCommand(string query);
		public abstract IDbConnection CreateConnection();
		public abstract IDbDataAdapter CreateDataAdapter(IDbCommand command);

		public virtual bool VerifyConnection()
		{
			bool isValid = false;
			try
			{
				IDbConnection connection = CreateConnection();
				connection.Open();
				if (connection.State == ConnectionState.Open)
				{
					isValid = true;
				}
				else
				{
					isValid = false;
				}
			}
			catch (Exception ex)
			{
				isValid = false;
				Console.WriteLine("DATABASE CONNECTION VERIFICATION FAILED");
			}


			return isValid;


		}

		public virtual DataSet GetDataSet(string query)
		{
			DataSet result = new DataSet();
			try
			{
				using (IDbCommand command = CreateCommand(query))
				{
					result = GetDataSet(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_DATA_SET :: {query} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return result;
		}

		public virtual DataTable GetDataTable(string query)
		{
			DataTable result = new DataTable();
			try
			{
				using (IDbCommand command = CreateCommand(query))
				{
					result = GetDataTable(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_DATA_TABLE :: {query} :: EXCEPTION MESSAGE :: {ex.Message}");
			}

			return result;
		}

		public virtual IDataReader GetReader(string query)
		{
			IDataReader result = null;
			try
			{
				using (var command = CreateCommand(query))
				{
					result = GetReader(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_READER :: {query} :: EXCEPTION MESSAGE :: {ex.Message}");
			}

			return result;

			//IDbConnection connection = CreateConnection();
			//connection.Open();
			//var command = CreateCommand(query);
			//command.Connection = connection;
			//return command.ExecuteReader(CommandBehavior.CloseConnection);

		}

		public virtual DataSet GetDataSet(IDbCommand command)
		{
			DataSet dataSet = new DataSet();
			try
			{
				using (IDbConnection connection = CreateConnection())
				{
					connection.Open();
					IDbDataAdapter dataAdapter = CreateDataAdapter(command);
					{

						dataAdapter.Fill(dataSet);

					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_DATA_SET :: {command} :: EXCEPTION MESSAGE :: {ex.Message}");
			}

			return dataSet;

		}

		public virtual DataTable GetDataTable(IDbCommand command)
		{
			DataTable dataTable = new DataTable();
			try
			{
				using (IDbConnection connection = CreateConnection())
				{
					connection.Open();
					command.Connection = connection;
					IDbDataAdapter dataAdapter = CreateDataAdapter(command);
					{
						DataSet dataSet = new DataSet();
						dataAdapter.Fill(dataSet);
						if (dataSet.Tables.Count > 0)
						{
							dataTable = dataSet.Tables[0];
						}
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_DATA_TABLE :: {command} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return dataTable;
		}

		public virtual IDataReader GetReader(IDbCommand command)
		{
			IDataReader reader = null;
			try
			{
				IDbConnection connection = CreateConnection();
				connection.Open();
				command.Connection = connection;
				reader = command.ExecuteReader();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_READER :: {command} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return reader;

		}

		public virtual object ExecuteScalar(string query)
		{
			object result = new();
			try
			{
				using (var command = CreateCommand(query))
				{
					result = ExecuteScalar(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN EXECUTE_SCALAR :: {query} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return result;
		}

		public virtual object ExecuteScalar(IDbCommand command)
		{
			object result = new();
			try
			{
				using (IDbConnection connection = CreateConnection())
				{
					connection.Open();
					command.Connection = connection;
					result = command.ExecuteScalar();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN EXECUTE_SCALAR :: {command} :: EXCEPTION MESSAGE :: {ex.Message}");
			}

			return result;
		}

		public virtual int ExecuteNonQuery(string query)
		{
			int rowcount = -1;
			try
			{
				using (var command = CreateCommand(query))
				{
					rowcount = ExecuteNonQuery(command);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN EXECUTE_NON_QUERY :: {query} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return rowcount;
		}

		public virtual int ExecuteNonQuery(IDbCommand command)
		{
			int rowcount = -1;
			try
			{
				using (IDbConnection connection = CreateConnection())
				{
					connection.Open();
					command.Connection = connection;
					rowcount = command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN EXECUTE_NON_QUERY :: {command} :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return rowcount;
		}
	}
}
