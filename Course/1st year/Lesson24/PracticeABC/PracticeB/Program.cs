using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Задача 1: Загрузка файла из сети по URL и сохранение его локально
        

        // Задача 2: Асинхронное чтение и запись файлов
        

        // Задача 3: Выполнение параллельных HTTP-запросов к нескольким серверам
        
 
    }

    static async Task DownloadFileAsync(string url, string filePath)
    {
        using (var httpClient = new HttpClient())
        {
            //отправка запроса на сервер
            if ( ) //проверка успешности запроса
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create)) 
                {
                    await ; // сохранение файла  c CopyToAsync(fileStream)
                }
            }
            else
            {
                Console.WriteLine("Ошибка загрузки файла.");
            }
        }
    }

    static async Task WriteToFileAsync(string filePath, string content)
    {
        using (var writer = new StreamWriter(filePath))
        {
            await  ; // запись в файл асинхронно
        }
        Console.WriteLine("Файл успешно записан.");
    }

    static async Task ReadFromFileAsync(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            
        }
    }

    static async Task FetchDataAsync(List<string> urls)
    {
        using (var httpClient = new HttpClient())
        {
             
        }
    }

     
}
