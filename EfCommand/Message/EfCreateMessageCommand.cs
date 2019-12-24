using Application.Commands.Message;
using Application.Dto.Message;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.Message
{
    public class EfCreateMessageCommand : ContextProvider, ICreateMessageCommand
    {
        public EfCreateMessageCommand(Context context) : base(context)
        {
        }

        public async Task Execute(MessageCreate request)
        {
            Context.Messages.Add(new DataAccess.Message
            {
                Text = request.Text,
                UserID = request.UserID,
            });

            await Context.SaveChangesAsync();
        }
    }
}
