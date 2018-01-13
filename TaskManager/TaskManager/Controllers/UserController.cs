using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.BLL.Services;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        UserService _userService;
        private readonly SignInManager<User> _signInManager;


        public UserController(UserService userService, SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {

            return View();

        }

        [HttpGet]
        public IActionResult Register()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUser(model);
                if (result.Result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(result.Data, false);
                    return RedirectToAction("Index", "Task");
                }
                else
                {
                    foreach (var error in result.Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return RedirectToAction("Index", "Task");
            }
            else
                return View();
           


        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model);

                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Task");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Task");
        }
    }
}
