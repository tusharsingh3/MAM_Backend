using System.Data;
using MAM.backend.Database;
using MAM.backend.Model;

namespace MAM.backend.Service.ServiceManager
{
	public abstract class UserManager
	{
		private DBManager _dbmanager;
		public UserManager(DBManager dbmanager)
		{
			_dbmanager = dbmanager;
		}
		public virtual List<User> GetAll()
		{
			List<User> result = new List<User>();
			try
			{
				string query = "SELECT * FROM User;";
				var command = _dbmanager.CreateCommand(query);
				DataTable dataTable = _dbmanager.GetDataTable(command);
				foreach (DataRow row in dataTable.AsEnumerable())
				{
					User user = new()
					{
						Id = row.Field<int>("Id"),
						Email = row.Field<string>("Email"),
						Name = row.Field<string>("Name")
					};
					result.Add(user);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR IN GET_ALL_BALL_CHANGE :: EXCEPTION MESSAGE :: {ex.Message}");
			}
			return result;
		}
	}
}
