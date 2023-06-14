using System.Globalization;
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

    public async Task<User?> JoinToRoom(int roomId, int userId)
    {
        return await _userService.JoinToRoom(roomId, userId);
    }
}