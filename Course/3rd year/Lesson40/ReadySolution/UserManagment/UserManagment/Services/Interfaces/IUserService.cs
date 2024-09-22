using UserManagment.Models;

namespace UserManagment.Services.Interfaces;

public interface IUserService
{
    void AddUser(string username, string email);
    void DeleteUser(int userId);
    User GetUser(int userId);
    IEnumerable<User> GetAllUsers();
}