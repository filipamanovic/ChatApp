using Application.Dto.User;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public interface ISetUserStatusCommand
    {
        Task Execute(string username, bool isLogged);
    }
}
