using Application.Commands.User;
using Application.Dto.User;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.User
{
    public class EfGetOneUserCommand : ContextProvider, IGetOneUserCommand
    {
        public EfGetOneUserCommand(Context context) : base(context)
        {
        }

        public async Task<UserEdit> Execute(int request)
        {
            var user = await Context.Users.FindAsync(request);

            if (user == null)
                throw new EntityNotFoundException("User");

            return new UserEdit
            {
                City = user.City,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName
            };
        }
    }
}
