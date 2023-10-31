using MAM.backend.Database;
using MAM.backend.Service.ServiceManager;

namespace MAM.backend.Service
{
    public class ServiceFactory
    {
        private DBManager _dbmanager;
        public ServiceFactory(DBManager dbmanager)
        {
            _dbmanager = dbmanager;
        }
        public UserManager CreateUserService(string databaseType)
        {
            switch (databaseType)
            {
                case "mssql":
                    return new MSSQLServices.UserServices(_dbmanager);
                case "mysql":
                    return new MYSQLServices.UserServices(_dbmanager);
                default:
                    throw new ArgumentException("Invalid database type.");
            }
        }
    }
}
