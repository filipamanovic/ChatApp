using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Message
{
    public class MessageJsToHub
    {
        public string Text { get; set; }
        public string Username { get; set; }
        public string CreatedAt { get; set; }
        public string ImagePath { get; set; }
    }
}
