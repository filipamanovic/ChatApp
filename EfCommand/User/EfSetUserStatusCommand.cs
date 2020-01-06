using Application.Commands.User;
using Application.Dto.User;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.User
{
    public class EfSetUserStatusCommand : ContextProvider, ISetUserStatusCommand
    {
        public EfSetUserStatusCommand(Context context) : base(context)
        {
        }

        public async Task Execute(string username, bool isLogged)
        {
            var user = Context.Users.Where(u => u.UserName == username).First();

            if (user == null)
                throw new EntityNotFoundException(username);

            if (isLogged)
            {
                user.LogoutTime = null;
            } else
            {
                user.LogoutTime = DateTime.Now;
            }

            user.IsLoged = isLogged;

            await Context.SaveChangesAsync();
        }
    }
}
