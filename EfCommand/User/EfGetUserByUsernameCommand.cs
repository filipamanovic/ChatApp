using Application.Commands.User;
using Application.Dto.User;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.User
{
    public class EfGetUserByUsernameCommand : ContextProvider, IGetUserByUsernameCommand
    {
        public EfGetUserByUsernameCommand(Context context) : base(context)
        {
        }

        public async Task<UserDisplay> Execute(string request)
        {
            var user = Context.Users.Where(u => u.UserName.ToLower() == request.ToLower()).First();
            return new UserDisplay
            {
                ImagePath = user.ImagePath,
                IsLogged = user.IsLoged,
                Username = user.UserName,
                UserID = user.Id
            };
        }
    }
}
