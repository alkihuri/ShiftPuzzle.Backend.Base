using Practices.Models;
using Practices.Services.Interfaces;

namespace Practices.Services.Implementations;

public class UserService : IUserService
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void EditUser(User user)
    {
        var existingUser = GetUser(user.UserId);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
        }
    }

    public void DeleteUser(int userId)
    {
        var user = GetUser(userId);
        if (user != null)
        {
            users.Remove(user);
        }
    }

    public User GetUser(int userId)
    {
        return users.FirstOrDefault(u => u.UserId == userId);
    }
    
    public IEnumerable<User> GetUsers()
    {
        return users;
    }
}