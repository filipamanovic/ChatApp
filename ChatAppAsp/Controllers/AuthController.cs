using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Dto.User;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppAsp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ISetUserStatusCommand _setUserStatus;

        public AuthController(UserManager<User> userManager, 
            SignInManager<User> signInManager, ISetUserStatusCommand setUserStatus)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _setUserStatus = setUserStatus;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDto user)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
                if (result.Succeeded)
                {
                    await _setUserStatus.Execute(user.Username, true);
                    return RedirectToAction("Index", "Home");
                }
                  
                TempData["msg"] = user.Username + " doesn't exist";
                return RedirectToAction("LoginPage");
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("LoginPage");
            }
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDto user)
        {
            try
            {
                User registerUser = await _userManager.FindByNameAsync(user.Username);
                if(registerUser != null)
                {
                    TempData["msg"] = "Username " + user.Username + " already exist!";
                    return RedirectToAction("RegisterPage");
                }
                else
                {
                    registerUser = new User();
                    registerUser.UserName = user.Username;
                    IdentityResult result = await _userManager.CreateAsync(registerUser, user.Password);
                    if (result.Succeeded)
                    {
                        var resultLogin = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
                        if (resultLogin.Succeeded)
                        {
                            await _setUserStatus.Execute(user.Username, true);
                            return RedirectToAction("Index", "Home");
                        }
             
                        TempData["msg"] = result.ToString();
                        return RedirectToAction("LoginPage");
                    }
                    else
                    {
                        TempData["msg"] = result.ToString();
                        return RedirectToAction("RegisterPage");
                    }
                }
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("RegisterPage");
            }
        }

        public async Task<IActionResult> Logout(string username)
        {
            await _signInManager.SignOutAsync();
            await _setUserStatus.Execute(username, false);
            return RedirectToAction("Index", "Home");
        }
    }
}