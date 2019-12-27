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
            var messageSkipVal = Context.Messages.Count() - 200;
            var messagesSkip = (messageSkipVal >= 0) ? messageSkipVal : 0;
            return await Context.Messages.Skip(messagesSkip)
                .Select(m => new MessageDto
                {
                    Text = m.Text,
                    CreatedAt = m.CreatedAt,
                    Username = m.User.UserName
                }).ToListAsync();
        }
    }
}
