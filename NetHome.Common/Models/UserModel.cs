using System;
using System.Collections.Generic;

namespace NetHome.Common
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}