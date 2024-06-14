Привет! Тебе предстоить сделать рефакторинг проекта с предыдшуего урока.

---
# Практика А:

1. Рефакторинг серверной части [Server/StoreController.cs]
-  В функции [WriteDataToFile] вынести работу с json в отдельную функцию    [ConvertDBtoJson]
-  В функции [WriteDataToFile] вынести работу с файлом в отдельную функцию  [WriteToDB]


---
# Практика В:

1. Рефакторинг серверной части [Server/StoreController.cs]

-  В функции [WriteDataToFile] вынести работу с json в отдельную функцию                [ConvertTextDBToList]
-  В функции [WriteDataToFile] вынести работу с файлом в отдельную функцию              [ReadDB]
-  В функции [WriteDataToFile] вынести проверку сущестования файла в отдельную функцию  [DBExist]

---
# Практика C:

1.   Рефакторинг клиентской части [Client/Program.cs]
- вынести адрес,порт и название методов в константы
  > подсказка
  ```C# const string url = "http://localhost" ```
  ```C# const string port = "5087" ```
  ```C# const string AddProductMethod = "/store/add" ```