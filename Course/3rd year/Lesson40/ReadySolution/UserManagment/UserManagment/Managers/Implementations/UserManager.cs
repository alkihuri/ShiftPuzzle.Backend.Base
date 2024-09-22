using UserManagment.Managers.Interfaces;
using UserManagment.Models;

namespace UserManagment.Managers.Implementations;

public class UserManager : IUserManager
{
    private readonly List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void DeleteUser(int userId)
    {
        var user = users.FirstOrDefault(u => u.Id == userId);
        if (user != null) users.Remove(user);
    }

    public User GetUser(int userId)
    {
        return users.FirstOrDefault(u => u.Id == userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return users;
    }
}
