namespace UserManagment.Services.Interfaces;

public interface IEmailService
{
    void SendEmail(string email, string message);
}