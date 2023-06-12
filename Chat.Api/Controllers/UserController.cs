using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Chat.Database;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Controllers;


[Route("/api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly ChatDbContext _db;

    public UserController(IUserService userService, ChatDbContext context)
    {
        _userService = userService;
        _db = context;
    }

    
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(ViewModels.LoginModel model)
    {
        Console.WriteLine("Entered!");
        if (ModelState.IsValid)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            Console.WriteLine(user.Login);
            if (user != null)
            {
                await Authenticate(model.Login);

                return RedirectToAction("Index", "Home");
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(ViewModels.RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            if (user == null)
            {
                _db.Users.Add(new User { Name = model.Name, Login = model.Login, Password = model.Password });
                await _db.SaveChangesAsync();

                await Authenticate(model.Login);

                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        }
        return View(model);
    }

    private async Task Authenticate(string userName)
    {
        
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
        
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        
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