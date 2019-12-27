using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}


