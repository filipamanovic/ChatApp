using Application.Commands.User;
using Application.Dto.User;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommand.User
{
    public class EfEditUserCommand : ContextProvider, IEditUserCommand
    {
        public EfEditUserCommand(Context context) : base(context)
        {
        }

        public async Task Execute(UserEdit request)
        {
            var user = await Context.Users.FindAsync(request.Id);

            if(request.Username != null)
            {
                if(user.UserName != request.Username)
                {
                    if (Context.Users.Any(u => u.UserName.ToLower() == request.Username))
                        throw new EntityAlreadyExistException("User");

                    user.UserName = request.Username;
                }               
            }

            if (request.ImagePath != null)
            {
                var oldImage = Directory.GetCurrentDirectory() + @"\wwwroot\uploads\" + user.ImagePath;
                if (File.Exists(oldImage)) 
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(oldImage);
                }
                    
                user.ImagePath = request.ImagePath;
            }
            if (request.FirstName != null)
                user.FirstName = request.FirstName;
            if (request.LastName != null)
                user.LastName = request.LastName;
            if (request.City != null)
                user.City = request.City;

            await Context.SaveChangesAsync();
        }
    }
}
