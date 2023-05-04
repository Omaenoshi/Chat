using System.Net;
using Chat.Domain.Entity;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
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

    [HttpPost]
    public async Task<int> Post(User user)
    {
        return await _userService.CreateUser(user);
    }
}