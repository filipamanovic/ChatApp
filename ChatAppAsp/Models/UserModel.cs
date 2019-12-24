using Application.Dto.Message;
using Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppAsp.Models
{
    public class UserModel
    {
        public IEnumerable<UserDisplay> Users { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}
