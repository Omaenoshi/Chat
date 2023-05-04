using System.Net;
using Chat.Domain.Entity;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Task<IEnumerable<User>> Get()
    {
        return _userService.GetUsers();
    }

    [HttpGet("{id}")]
    public Task<User> Get(int id)
    {
        return _userService.GetUserById(id);
    }

    [HttpPost]
    public bool Post(User user)
    {
        return _userService.CreateUser(user);
    }
}