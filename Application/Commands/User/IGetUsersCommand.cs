using Application.Dto.User;
using Application.Interfaces;
using Application.Queries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IGetUsersCommand : ICommand<UserQuery, IEnumerable<UserDisplay>>
    {

    }
}
