using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Common;
using WebApplication8.Database;
using WebApplication8.Repositroy.Interface;

namespace WebApplication8.Repositroy.Concerate
{
    public class UserRepositroy : IUserRepositroy
    {
        private readonly NTireCrudContext nTireCrudContext;

        public UserRepositroy()
        {
           nTireCrudContext = new NTireCrudContext();
        }
        public bool AddUser(User user)
        {
           nTireCrudContext.Users.Add(user);   
           return nTireCrudContext.SaveChanges()>0?true: false;
        }

        public bool CheckLogin(string username, string password,out string message)
        {

            var d = nTireCrudContext.Users.FirstOrDefault(y => y.Name == username);
            
            if(d == null)
            {
                message = "user name not found";
                return false;
            }

            var encode = Helper.EncodePassword(password, d.PasswordSalt);

            if(encode != d.Password)
            {
                message = "password is not valid";
                return false;
            }
            message = "login sucessfully";

            return true;    

        }

        public bool DeleteUser(int userId)
        {
            var d = nTireCrudContext.Users.SingleOrDefault(y => y.Id == userId);
            nTireCrudContext.Users.Remove(d);
            return nTireCrudContext.SaveChanges() > 0 ? true : false;

        }

        public User GetUser(int userId)
        {
            return nTireCrudContext.Users.Find(userId);
        }

        public List<User> GetUsers()
        {
            return nTireCrudContext.Users.ToList();
        }
    }
}
