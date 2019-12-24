using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChatAppAsp.Models;
using Application.Dto.User;
using Application.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using Application.Commands.User;
using Application.Queries.User;
using Microsoft.AspNetCore.Identity;
using DataAccess;
using Application.Commands.Message;
using Application.Queries.Message;
using Application.Dto.Message;

namespace ChatAppAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IGetUsersCommand _getUsers;
        private readonly UserModel _userModel;
        private readonly IGetMessagesCommand _getMessages;
        private readonly ICreateMessageCommand _createMessage;

        public HomeController(UserManager<User> userManager, 
            IGetUsersCommand getUsers, UserModel userModel, 
            IGetMessagesCommand getMessages, ICreateMessageCommand createMessage)
        {
            _userManager = userManager;
            _getUsers = getUsers;
            _userModel = userModel;
            _getMessages = getMessages;
            _createMessage = createMessage;
        }

        public async Task<ActionResult> Index([FromQuery] UserQuery userQuery, MessageQuery messageQuery)
        {
            _userModel.Users = await _getUsers.Execute(userQuery);
            _userModel.Messages = await _getMessages.Execute(messageQuery);
            return View(_userModel);
        }

        public async Task<IActionResult> Create(MessageCreate messageCreate)
        {
            var user = await _userManager.GetUserAsync(User);
            messageCreate.UserID = user.Id;
            await _createMessage.Execute(messageCreate);
            return Ok();
        }
    }
}
