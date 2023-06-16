using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services;
using WebApplication1.Shared;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        AccountService _AccountService;
        PasswordManager _PasswordManager;
        public AccountController(AccountService accountService, PasswordManager passwordManager)
        {
            _AccountService = accountService;
            _PasswordManager = passwordManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                User user = _AccountService.GetUser(loginUser.Email);

                if (user == null || !_PasswordManager.CheckPassword(user.Password, loginUser.Password))
                {
                    ViewBag.Error = "Wrong Email or Password!";
                    ModelState.Remove("Password");
                    return View();
                }

                ClaimsIdentity claimsIdentity = _PasswordManager.GenerateClaims(user);

                await HttpContext.SignInAsync
                (
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = DateTime.UtcNow.AddDays(5),
                    }
                );

                if (Url.IsLocalUrl(loginUser.ReturnUrl))
                {
                    return Redirect(loginUser.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                if (_AccountService.GetUser(user.Email) == null)
                {
                    user.Password = _PasswordManager.GeneratePassword(user.Password);
                    _AccountService.CreateUser(user);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email is already taken.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
