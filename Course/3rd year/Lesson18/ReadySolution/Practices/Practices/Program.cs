using System;
using Practices;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=contacts.db;Version=3;";
        var repository = new ContactRepository(connectionString);

        // Создаем базу данных и таблицу
        repository.CreateTable();
        Console.WriteLine("База данных и таблица созданы.");

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Удалить контакт");
            Console.WriteLine("3. Поиск контактов");
            Console.WriteLine("4. Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя: ");
                    var nameToAdd = Console.ReadLine();
                    Console.Write("Введите номер телефона: ");
                    var phoneToAdd = Console.ReadLine();
                    repository.AddContact(nameToAdd, phoneToAdd);
                    Console.WriteLine("Контакт добавлен.");
                    break;
                case "2":
                    Console.Write("Введите ID контакта для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out var idToDelete))
                    {
                        repository.DeleteContact(idToDelete);
                        Console.WriteLine("Контакт удален.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный ID.");
                    }
                    break;
                case "3":
                    Console.Write("Введите имя для поиска: ");
                    var nameToSearch = Console.ReadLine();
                    repository.SearchContacts(nameToSearch);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
