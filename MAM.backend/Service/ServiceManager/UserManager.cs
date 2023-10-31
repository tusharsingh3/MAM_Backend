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
            string query = "SELECT * FROM USER";
            return new List<User>();
        }
    }
}
