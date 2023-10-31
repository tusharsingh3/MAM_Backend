using MAM.backend.Database;
using MAM.backend.Model;
using MAM.backend.Service.ServiceManager;

namespace MAM.backend.Service.MYSQLServices
{
	public class UserServices : UserManager
	{
		public UserServices(DBManager dbmanager) : base(dbmanager)
		{

		}
	}
}
