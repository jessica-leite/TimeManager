﻿using System;
using System.Collections.Generic;

namespace TimeManager.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string SecretAnswer { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
    }
}