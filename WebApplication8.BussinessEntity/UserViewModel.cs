using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication8.BussinessEntity
{
    public class UserViewModel : UserViewModelBase
    {


        [Range(1,20000, ErrorMessage ="pleae enter valida saalry")]
        public int Salary { get; set; }
        [Required(ErrorMessage ="Please enter password")]

        [Phone(ErrorMessage ="please ")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.*\d)[A-Za-z\d!@#$%^&*]{8}$", ErrorMessage ="Please enter valida password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter ConfirmPassword")]
        [Compare("Password", ErrorMessage ="Password and confirma password should be same")]
        public string ConfirmPassword { get; set; }
    }
}

