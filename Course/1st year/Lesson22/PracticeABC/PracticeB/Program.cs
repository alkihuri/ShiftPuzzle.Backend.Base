public class Program
{
    // список почтовых ящиков
    private static readonly List<Mail.Mail> Mails = new List<Mail.Mail>()
    {
        new Mail.Mail("user1@mail.com"),
        new Mail.Mail("user2@mail.com"),
        new Mail.Mail("user3@mail.com"),
        new Mail.Mail("user4@mail.com"),
        new Mail.Mail("user5@mail.com"),
    };
    
    public static void Main(string[] args)
    {
        foreach (var mail in Mails)
        {
            mail.CreateRandomLetters(10);
        }
        
        // TODO: Практика B.1. Найти старые письма (!IsNew) с почтовым ящиком user1@mail.com 
        

        // TODO: Практика B.2. Найти время самого нового письма (Received) для почтового ящика user4@mail.com
        
    }
}