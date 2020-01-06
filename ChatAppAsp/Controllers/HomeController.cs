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
using Application.Helpers;
using ChatAppAsp.Hubs;

namespace ChatAppAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IGetUsersCommand _getUsers;
        private readonly UserModel _userModel;
        private readonly IGetMessagesCommand _getMessages;
        private readonly ICreateMessageCommand _createMessage;
        private readonly IGetOneUserCommand _getOneUser;
        private readonly IEditUserCommand _editUser;
        private readonly ImageUpload _imageUpload;
        private readonly ChatHub _chatHub;
        private readonly IGetUserByUsernameCommand _getUserByUsername;

        public HomeController(UserManager<User> userManager,
            IGetUsersCommand getUsers, UserModel userModel,
            IGetMessagesCommand getMessages, ICreateMessageCommand createMessage,
            IGetOneUserCommand getOneUserCommand, IEditUserCommand editUserCommand,
            ImageUpload imageUpload, ChatHub chatHub, IGetUserByUsernameCommand getUserByUsernameCommand,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _getUsers = getUsers;
            _userModel = userModel;
            _getMessages = getMessages;
            _createMessage = createMessage;
            _getOneUser = getOneUserCommand;
            _editUser = editUserCommand;
            _imageUpload = imageUpload;
            _chatHub = chatHub;
            _getUserByUsername = getUserByUsernameCommand;
            _signInManager = signInManager;
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

        public async Task<IActionResult> Edit()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var userData = await _getOneUser.Execute(user.Id);
                return View(userData);
            }
            catch (EntityNotFoundException e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UserEdit userEdit)
        {
            try
            {
                await _signInManager.SignOutAsync();
                var user = await _userManager.GetUserAsync(User);
                userEdit.Id = user.Id;
                userEdit.ImagePath = await _imageUpload.uploadImage(userEdit.Image);
                await _editUser.Execute(userEdit);
                TempData["msg"] = "Succesfully edited user";
                var editedUser = await _getOneUser.Execute(user.Id);
                var profileUpdate = await _getUserByUsername.Execute(editedUser.Username);
                await _chatHub.SendProfile(profileUpdate);
                var userJedi = await _userManager.FindByNameAsync(profileUpdate.Username);
                await _signInManager.SignInAsync(userJedi, false);
                return RedirectToAction("Index");
            }
            catch (EntityAlreadyExistException e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Edit");
            }
            catch (ImageExtensionNotAllowedException e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Edit");
            }
            catch (ImageFileSizeNotAllowedException e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Edit");
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
