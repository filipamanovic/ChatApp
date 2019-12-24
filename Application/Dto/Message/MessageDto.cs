using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Message
{
    public class MessageDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
    }
}
