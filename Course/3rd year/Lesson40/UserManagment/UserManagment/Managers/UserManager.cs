using UserManagment.Models;

namespace UserManagment.Managers;

public class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        // Добавление пользователя
        users.Add(user);
        SendWelcomeEmail(user.Email);
    }

    public void DeleteUser(int userId)
    {
        // Удаление пользователя
        var user = users.FirstOrDefault(u => u.Id == userId);
        if (user != null) users.Remove(user);
    }

    public User GetUser(int userId)
    {
        // Получение пользователя
        return users.FirstOrDefault(u => u.Id == userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        // Получение всех пользователей
        return users;
    }

    private void SendWelcomeEmail(string email)
    {
        // Логика отправки email
        Console.WriteLine($"Sending welcome email to {email}");
    }
}
