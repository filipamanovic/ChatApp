using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.User
{
    public class UserDisplay
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public bool IsLogged { get; set; }
        public string ImagePath { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
