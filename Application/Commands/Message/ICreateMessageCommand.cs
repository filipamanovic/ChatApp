using Application.Dto.Message;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Message
{
    public interface ICreateMessageCommand : ICommand<MessageCreate>
    {
    }
}
