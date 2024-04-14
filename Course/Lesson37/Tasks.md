

---
# Практика А:

1. Реализовать верификацию данных при регистарции данных.

Подсказка для почты: 

``` 
Пусть domens = ["ru", "com", "com"]

Если account.Name содержит символ "@" 
    И account.Name содержит символ "."
    И длина account.Name больше 5
    И длина account.Name меньше 50
    И хотя бы один элемент из domens содержится в account.Name после последней точки
Тогда
    Присвоить account.Email значение account.Name
    Присвоить account.Name значение первой части строки account.Name до символа "@"
    Вывести на экран "Email пользователя account.Name действителен."
Иначе
    Присвоить account.Email значение account.Name
Конец если
```

--- 
# Практика B: 
1. Реализовать авторизацию/верификацию пользовалять в методе Create AccountController.cs 
> ПОДСКАЗКА:

>> В части фронтеда обработка регистрации выглядит так:

```
fetch('/api/account/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(userData)
                })
                .then(response => response.json())
                .then(data => {
                    // если данные получены и не bad request
                    
                    if (data.isVerified) {
                        currentUser = data.user;
                        // Регистрация выполнена успешно, выводим сообщение об успехе
                        registrationMessage.innerText = "Регистрация успешно завершена.";
                        /// остальная часть логики
                    } 
                    else if(!data.isVerified){
                        // Регистрация не удалась, выводим сообщение об ошибке  
                        console.log("sueta");
                        registrationMessage.innerText = "Ошибка регистрации. Пользователь с таким именем уже существует."; 
                        setTimeout(() => {
                            registrationMessage.style.display = 'none';
                        }, 2000); 
                    }
                })
                .catch(error => { 
                    
                });
            });
```

>> Сейчас логика просто возвращает User, но для полноченного ответа который правильно считается фронтом можно: 
1. либо добавить поле IsAuthorized и поменять логику на части фронта  с ```if (data.isVerified)``` на ```if (data.user.isVerified)```
2. либо создать новую структуры данных и завернуть туда пользователя и свойство IsAutorized

``` 
class Response
{
    User user;
    bool IsAutorized;
}
```

3. Либо использовать самый простой вариант: 

```

    [HttpPost("/api/account/register")]
    public IActionResult Create([FromBody] User account)
    {
         Console.WriteLine("Registering account: " + account.Name); 
        _accountManager.RegisterAccount(account);

        bool isVerified = _accountManager.VerifyAccount(account);
        
        // Создаем объект для ответа, который содержит информацию о пользователе и его статусе верификации
        var response = new {
            User = account,
            IsVerified = isVerified
        };

        return Ok(response);
    }
```

--- 
# Практика C:

1. Реализовать журналирование каждого шага пользователей в работе с ЗАДАЧАМИ и с Аккаунтом в таск трекере в файл ActionsLog.csv
где указаны : 1. Дата 2. Пользователь 3. Действие

>Подсказка: 

```
    public static void Logger(User account,string action)
    { 
        string logMessage = $"{account.Name},{account.Password},{DateTime.Now},{action}\n"; 
        File.AppendAllText("ActionsLog.csv", logMessage);
    }
```