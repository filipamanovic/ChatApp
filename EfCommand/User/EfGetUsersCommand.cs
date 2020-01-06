using Application.Commands.User;
using Application.Dto.User;
using Application.Queries.User;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.User
{
    public class EfGetUsersCommand : ContextProvider, IGetUsersCommand
    {
        public EfGetUsersCommand(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<UserDisplay>> Execute(UserQuery request)
        {
            var query = Context.Users.AsQueryable();
            if (request.Username != null)
                query = query.Where(u => u.UserName.Contains(request.Username));

            
            return await query.Select(u => new UserDisplay
            {
                UserID = u.Id,
                Username = u.UserName,
                IsLogged = u.IsLoged,
                ImagePath = u.ImagePath,
                LogoutTime = u.LogoutTime
            }).OrderBy(u => !u.IsLogged).ToListAsync();
        }
    }
}
