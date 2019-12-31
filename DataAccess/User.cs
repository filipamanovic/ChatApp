using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User : IdentityUser<int>
    {
        public bool IsLoged { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
