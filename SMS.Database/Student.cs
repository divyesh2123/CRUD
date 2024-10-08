﻿using System;
using System.Collections.Generic;

namespace SMS.Database
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string? Address { get; set; }
    }
}
