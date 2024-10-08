using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Database;

namespace WebApplication8.Repositroy.Interface
{
    public interface IUserRepositroy
    {
        bool AddUser(User user);

        List<User> GetUsers();  

        bool DeleteUser(int userId);

        User GetUser(int userId);

        bool CheckLogin(string username, string password, out string message);


        bool IsEmailAlreadyInUse(string emailId);
    }
}
