Привет! Тебе предстоить сделать рефакторинг проекта с предыдшуего урока. 

---
# Практика А:

1. Запустить пример проекта по загрузке видео и записи в файл

> [ПРИМЕР](https://github.com/alkihuri/ShiftPuzzle.Backend.Base/tree/main/Course/Lesson24/PracticeABC/Example) 


---
# Практика В: 

1. Решить задачи в папке AssyncTasks


> Подсказки:
## Загрузка файла из сети по URL и сохранение его локально

```csharp
string url = "https://emojiisland.com/cdn/shop/products/Emoji_Icon_-_Clown_emoji_large.png";
string localFilePath = "clown.png";
await DownloadFileAsync(url, localFilePath);
```
## Асинхронное чтение и запись файлов
```csharp
string filePath = "input.txt";
await WriteToFileAsync(filePath, "Привет, мир!");
await ReadFromFileAsync(filePath);
```
## Выполнение параллельных HTTP-запросов к нескольким серверам
```csharp
List<string> urls = new List<string> { "http://google.com", "http://yandex.ru", "http://yahoo.com" };
await FetchDataAsync(urls);
```




# Практика C:

1. Переписать все методы СУБД с прошлого урока на ассинхронные
 
 
