using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.BussinessEntity;

namespace WebApplication8.BussinessService
{
public interface IUserService
{
        bool AddUserInfo(UserViewModel userViewModel);

        List<UserViewModelBase> GetUsers();

        bool DeleteUser(int userId);

        UserViewModel GetUser(int userId);

        bool CheckLogin(string username, string password, out string message);
    }
}
