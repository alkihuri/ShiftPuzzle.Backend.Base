public class Program
{
    public static void Main(string[] args)
    {
        // почтовый ящик пользователя
        var mail = new Mail.Mail("user1@mail.com");
        mail.CreateRandomLetters(10);
        
        // Получение количества новых писем
        var countNewLetters_classic = mail.GetNewLetterIds_Classic();
        Console.WriteLine($"Количество новых писем (Classic): {countNewLetters_classic.Count}");
        
        var countNewLetters_linq = mail.GetNewLetterIds_Linq();
        Console.WriteLine($"Количество новых писем (Linq): {countNewLetters_linq.Count}");
        
        // Сортировка писем по дате получения
        // TODO: Задание 2. для mail вызовите метод SortByRecived_Linq и выведите полученные письма
        
    }
}