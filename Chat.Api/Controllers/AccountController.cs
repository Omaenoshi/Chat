using Chat.Api.ViewModels;
using Chat.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Chat.Service.Interface;

namespace Chat.Api.Controllers
{
    [Route("/account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            var user = await _userService.GetUserByLoginAndPassword(model.Login, model.Password);
            if (user != null)
            {
                await Authenticate(model.Login, user.Id);
                return RedirectToAction("Index", "Home");
            }
            //if (ModelState.IsValid)
            //{
            //    var user = await _userService.GetUserByLoginAndPassword(model.Login, model.Password);
            //    if (user != null)
            //    {
            //        await Authenticate(model.Login, user.Id);
            //        return RedirectToAction("Index", "Home");
            //    }

            //    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}

            return View(model);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByLoginAndPassword(model.Login, model.Password);
                if (user == null)
                {
                    var userId = await _userService.CreateUser(new User() { Login = model.Login, Name = model.Name, Password = model.Password });

                    await Authenticate(model.Login, userId);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        private async Task Authenticate(string userName, int userId)
        {
            var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, userName),
            new("UsedId", userId.ToString())
        };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
