namespace PracticeA; 
class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        // 6. Открытие нового счета
        var account1 = bank.OpenAccount("Alexander Ivanov");
        var account2 = bank.OpenAccount("Alexander Ivanov");

        // Внесение денег на счет 1
        account1.Deposit(1000);

        // 2. Отправка денег
        bank.Transfer(account1.AccountNumber, account2.AccountNumber, 500);

        // 4. Показать остаток
        Console.WriteLine($"Balance of Account 1: {bank.CheckBalance(account1.AccountNumber)}");
        Console.WriteLine($"Balance of Account 2: {bank.CheckBalance(account2.AccountNumber)}");

        // 5. Выписка по счету
        bank.PrintStatement(account1.AccountNumber);
        bank.PrintStatement(account2.AccountNumber);

        // 3. Отмена операции (примерный вызов, детали реализации не определены)
        bank.CancelLastTransaction(account1.AccountNumber);

        // 7. Закрытие счета
        bank.CloseAccount(account2.AccountNumber);

        // 8. Запрос кредита
        bank.RequestLoan(account1.AccountNumber, 5000);

        // 9. Платеж по кредиту
        bank.GetLoan(account1.AccountNumber, 500);

        // 10. Изменение личных данных клиента
        bank.UpdateAccountHolderInfo(account1.AccountNumber, "Alexander Ivanov");

        // 1. Получение счета и вывод его данных
        var retrievedAccount = bank.GetAccount(account1.AccountNumber);
        if (retrievedAccount != null)
        {
            Console.WriteLine($"Retrieved Account: {retrievedAccount.AccountNumber}, Holder: {retrievedAccount.AccountHolder}");
        }
    }
}
