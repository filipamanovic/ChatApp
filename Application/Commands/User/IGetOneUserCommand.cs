using Application.Dto.User;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetOneUserCommand : ICommand<int, UserEdit>
    {
    }
}
