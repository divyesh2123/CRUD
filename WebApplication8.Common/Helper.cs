using System.Security.Cryptography;
using System.Text;
using WebApplication8.BussinessEntity;
using WebApplication8.Database;

namespace WebApplication8.Common
{
    public static class Helper
    {
        public static User ToDataModel(this UserViewModel userViewModel)
        {
            User user = new User();
            user.Address1 = userViewModel.Address1;
            user.Address2 = userViewModel.Address2;
            user.Name = userViewModel.Name;
            user.PasswordSalt = GeneratePassword(6);
            user.Password = EncodePassword(userViewModel.Password, user.PasswordSalt);
            return user;

        }

        public static UserViewModel ToViewModelForRegistration(this User user)
        {
            UserViewModel d = new UserViewModel();
            d.Address1 = user.Address1;
            d.Address2 = user.Address2;
            d.Name = user.Name;
            d.Password = user.Password;
            return d;

        }

        public static UserViewModelBase ToViewModel(this User user)
        {
            UserViewModelBase userViewModelBase = new UserViewModelBase();
            userViewModelBase.Address1 = user.Address1;
            userViewModelBase.Address2 = user.Address2;
            userViewModelBase.Name = user.Name;
            userViewModelBase.Id = user.Id;

            return userViewModelBase;

        }

        public static List<UserViewModelBase> ToViewModel(this List<User> user)
        {
            return user.Select(x => x.ToViewModel()).ToList();



        }

        //random key
        public static string GeneratePassword(int length) //length of salt    
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }


        public static string EncodePassword(string pass, string salt) //encrypt password    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }
    }
}