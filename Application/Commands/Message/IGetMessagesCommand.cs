using Application.Dto.Message;
using Application.Interfaces;
using Application.Queries.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Message
{
    public interface IGetMessagesCommand : ICommand<MessageQuery, IEnumerable<MessageDto>>
    {
    }
}
