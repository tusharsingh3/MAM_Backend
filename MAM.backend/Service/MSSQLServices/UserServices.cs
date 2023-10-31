using MAM.backend.Database;
using MAM.backend.Service.ServiceManager;

namespace MAM.backend.Service.MSSQLServices
{
	public class UserServices : UserManager
	{
		public UserServices(DBManager dbmanager) : base(dbmanager)
		{

		}
	}
}
