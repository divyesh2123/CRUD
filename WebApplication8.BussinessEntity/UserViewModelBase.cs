﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication8.Common;

namespace WebApplication8.BussinessEntity
{
    public class UserViewModelBase
    {
        [Required(ErrorMessage ="Please Enter Name")]
        [MaxLength(12,ErrorMessage ="Max only 12 char allowed")]
        [MinLength(4,ErrorMessage ="Min only 4 char length allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address1")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Please Enter Address2")]
        public string Address2 { get; set; }

       
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        [Remote(action: "IsEmailAvailable", controller: "User", ErrorMessage = "Email is already in use. Please use a different email address.")]
        public string Email { get; set; }   

        public int Id { get; set; } 
       
    }
}