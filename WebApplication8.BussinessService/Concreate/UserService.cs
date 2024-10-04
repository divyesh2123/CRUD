using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.BussinessEntity;
using WebApplication8.Common;
using WebApplication8.Repositroy.Concerate;
using WebApplication8.Repositroy.Interface;

namespace WebApplication8.BussinessService.Concreate
{
    public class UserService : IUserService
    {
        private readonly IUserRepositroy userRepositroy;

        public UserService()
        {
            userRepositroy = new UserRepositroy();

        }
        public bool AddUserInfo(UserViewModel userViewModel)
        {
            return userRepositroy.AddUser(userViewModel.ToDataModel());
        }

        public bool CheckLogin(string username, string password, out string message)
        {
            return userRepositroy.CheckLogin(username,password,out message);
        }

        public bool DeleteUser(int userId)
        {
            return userRepositroy.DeleteUser(userId);
        }

        public UserViewModel GetUser(int userId)
        {
            return userRepositroy.GetUser(userId).ToViewModelForRegistration();
        }

        public List<UserViewModelBase> GetUsers()
        {
            var users = userRepositroy.GetUsers();
            return users.ToViewModel();
        }
    }
}
