using Practices.Models;

namespace Practices.Services.Interfaces;

public interface IUserService
{
    public void AddUser(User user);
    public void EditUser(User user);
    public void DeleteUser(int userId);
    public User GetUser(int userId);
    public IEnumerable<User> GetUsers();
}