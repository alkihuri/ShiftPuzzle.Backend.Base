
---
# Практика А:

1. Создать интерфейс IAccountManager

> ПОДСКАЗКА:

```C#
public interface IAccountManager
{
    void RegisterAccount(User account); 
    User GetAccount(string accountName);
    List<User> GetAccounts(); 
    bool VerifyAccount(User account);
}
```

2. Создать реализацию AccountManager с логикой взаимодействия с СУБД в контексте EFCORE

> ВАЖНО: 

На данном этапе можно пока оставить заглушки под методы, а в конструкторе AccountManager указать инъекцию зависимости AccountContext, который пока не реализован
 
--- 
# Практика B: 
1. Создать реализацию AccountContext
2. Реализовать логику взаимодействия AccountManager и  AccountContext
> ПРИМЕР:
```C#
public bool VerifyAccount(User account)
{
    if(_context.Users.Any(u => u.Name == account.Name && u.Password == account.Password))
    {
        CurrentUser = account;
        Console.WriteLine("Account verified.");
        return true;    
    }
    else 
    {
        Console.WriteLine("Account not verified.");
        return false; 
    }    
}
``` 
--- 
# Практика C:

1. Создать контроллер AccountController со всеми endpoint'ами и инъекцией AccountManager



> Подсказки:


# Списки ENDPOINT`ОВ:


>>> [HttpPost("api/account/verify")]      

>>> [HttpPost("/api/account/register")]   

>>> [HttpGet("/api/account/get/{name}")] 

>>> [HttpGet("/api/account/getall")]



# Настройка зависимостей в [Programm.cs]
```C#
builder.Services.AddSingleton<IAccountManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();
    optionsBuilder.UseSqlite("Data Source=ПУТЬ К БАЗЕ.db"); 
    var accountContext = new AccountContext(optionsBuilder.Options);
    accountContext.Database.EnsureCreated();  
    IAccountManager accountManager = new AccountManager(accountContext);

    return accountManager;
});
```
