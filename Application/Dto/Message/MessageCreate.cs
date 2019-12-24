using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Message
{
    public class MessageCreate
    {
        public string Text { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
