using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Common;

namespace WebApplication8.BussinessEntity
{
    public class UserViewModel : UserViewModelBase
    {


      
      
        [Phone(ErrorMessage ="please ")]
        
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [Compare("Password", ErrorMessage ="Password and confirma password should be same")]
        public string ConfirmPassword { get; set; }
    }
}

