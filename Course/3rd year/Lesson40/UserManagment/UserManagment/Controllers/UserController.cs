using Microsoft.AspNetCore.Mvc;
using UserManagment.Managers;
using UserManagment.Models;

namespace UserManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager userManager = new UserManager();

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(string username, string email)
    {
        var user = new User { Username = username, Email = email };
        userManager.AddUser(user);
        return Content($"User {username} created.");
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(int userId)
    {
        userManager.DeleteUser(userId);
        return Content($"User with ID {userId} removed.");
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(int userId)
    {
        var user = userManager.GetUser(userId);
        if (user != null)
        {
            return Content($"User: {user.Username}, Email: {user.Email}");
        }
        else
        {
            return Content("User not found.");
        }
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        var users = userManager.GetAllUsers();
        var userList = string.Join("<br/>", users.Select(u => $"User: {u.Username}, Email: {u.Email}"));
        return Content(userList);
    }
}
