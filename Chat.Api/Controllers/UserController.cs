using Chat.Domain;
using Chat.Service.Interface;
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

    [HttpPost]
    public async Task<int> Post(User user)
    {
        return await _userService.CreateUser(user);
    }

    [HttpDelete("{id}")]
    public async Task<int> Delete(int id)
    {
        return await _userService.DeleteUserById(id);
    }
    [HttpGet]
    public async Task<int> Update(User user)
    {
        return await _userService.UpdateUser(user);
    }
}