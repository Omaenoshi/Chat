using System.Security.Claims;
using Chat.Api.ViewModels;
using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("/api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.GetUserByLoginAndPassword(model.Login, model.Password);
            if (user != null)
            {
                await Authenticate(model.Login, user.Id);
                return RedirectToAction("Index", "Room");
            }

            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }

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
                var userId = await _userService.CreateUser(new User() {Login = model.Login, Name = model.Name, Password = model.Password});

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
        return RedirectToAction("Login", "User");
    }

    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _userService.GetUsers();
    }

    [HttpGet("{id}")]
    public async Task<User> Get(int id)
    {
        return await _userService.GetUserById(id);
    }

    [HttpDelete("{id}")]
    public async Task<int> Delete(int id)
    {
        return await _userService.DeleteUserById(id);
    }

    [HttpPut]
    public async Task<int> Update(User user)
    {
        return await _userService.UpdateUser(user);
    }
}