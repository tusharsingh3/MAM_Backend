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
        //public override List<User> GetAll()
        //{
        //    string query = "SELECT * FROM USER";
        //    return new List<User>();
        //}
    }
}
