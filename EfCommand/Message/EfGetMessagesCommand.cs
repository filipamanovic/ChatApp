using Application.Commands.Message;
using Application.Dto.Message;
using Application.Queries.Message;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.Message
{
    public class EfGetMessagesCommand : ContextProvider, IGetMessagesCommand
    {
        public EfGetMessagesCommand(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<MessageDto>> Execute(MessageQuery request)
        {
            return await Context.Messages.Select(m => new MessageDto
            {
                Text = m.Text,
                CreatedAt = m.CreatedAt,
                Username = m.User.UserName
            }).ToListAsync();
        }
    }
}
