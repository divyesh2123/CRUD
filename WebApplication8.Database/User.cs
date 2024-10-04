using System;
using System.Collections.Generic;

namespace WebApplication8.Database
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Password { get; set; }
        public string? PasswordSalt { get; set; }
    }
}
