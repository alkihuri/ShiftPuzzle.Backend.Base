using UserManagment.Services.Interfaces;

namespace UserManagment.Services.Implementations;

public class EmailService : IEmailService
{
    public void SendEmail(string email, string message)
    {
        // Логика отправки email
        Console.WriteLine($"Sending email to {email}: {message}");
    }
}