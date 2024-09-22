using Microsoft.AspNetCore.Mvc;
using UserManagment.Managers;
using UserManagment.Models;
using UserManagment.Services.Interfaces;

namespace UserManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(string username, string email)
    {
        userService.AddUser(username, email);

        return Ok();
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(int userId)
    {
        userService.DeleteUser(userId);
        
        return Ok();
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(int userId)
    {
        var user = userService.GetUser(userId);
        if (user != null)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        var users = userService.GetAllUsers();

        return Ok(users);
    }
}
