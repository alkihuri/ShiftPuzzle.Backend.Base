Привет! Тебе предстоить сделать рефакторинг проекта с предыдшуего урока. 

---
# Практика АB:

1. Решить задачи из папки PRACTICE AB

--- 
 
# Практика C:

1. Добавить в решение с СУБД событые для каждого метода (1. доавбление 2. удаление 3. обновление).
2. Также осуществить настрокку подписки под события в конструктре: 
 
>ПРИМЕР: 
```C#
        public EFCoreProductRepository(ProductContext context)
        {
            _context = context;  
            OnProductAdded  +=   SendNotificationToStatDepartmetn;  
        }
```
> ВАЖНО: 

- методы не надо реализовывать на 100%, достачтоно мокать (зашлушка)
>> ПРИМЕР:

```C#
        private void SendNotificationToStatDepartmetn()
        {
           Console.WriteLine("Отправляю отчет в отдел статистики...");
        }
```