using UserManagment.Models;

namespace UserManagment.Managers.Interfaces;

public interface IUserManager
{
    void AddUser(User user);
    void DeleteUser(int userId);
    User GetUser(int userId);
    IEnumerable<User> GetAllUsers();
}