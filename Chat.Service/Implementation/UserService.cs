using System.Security.Claims;
using Chat.Database.Interface;
using Chat.Domain;
using Chat.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Chat.Service.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private async Task Authenticate(HttpContext context, string userName)
    {

        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        };

        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<int> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<int> DeleteUserById(int id)
    {
        return await _userRepository.DeleteById(id);
    }

    public async Task<int> UpdateUser(User user)
    {
        return await _userRepository.Update(user);
    }
}