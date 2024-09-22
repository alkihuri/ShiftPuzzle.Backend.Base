using UserManagment.Managers.Interfaces;
using UserManagment.Models;
using UserManagment.Services.Interfaces;

namespace UserManagment.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserManager userManager;
    private readonly IEmailService emailService;

    public UserService(IUserManager userManager, IEmailService emailService)
    {
        this.userManager = userManager;
        this.emailService = emailService;
    }

    public void AddUser(string username, string email)
    {
        var user = new User { Username = username, Email = email };
        userManager.AddUser(user);
        emailService.SendEmail(email, "Welcome!");
    }

    public void DeleteUser(int userId)
    {
        userManager.DeleteUser(userId);
    }

    public User GetUser(int userId)
    {
        return userManager.GetUser(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return userManager.GetAllUsers();
    }
}