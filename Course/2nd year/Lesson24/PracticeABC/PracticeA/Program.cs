// пример метода для загрузки видео  с помощью HttpClient
async Task<byte[]> LoadVideoAsync(string url)
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync(url);
    return await response.Content.ReadAsByteArrayAsync();
}

// пример метода для сохранения видео в файл
async Task SaveVideoAsync(string path, byte [] content)
{
    await File.WriteAllBytesAsync(path, content);
}

// пример метода для загрузки видео и сохранения его в файл
async Task LoadAndSaveVideoAsync(string url, string path)
{
    byte [] content = await LoadVideoAsync(url);
    await SaveVideoAsync(path, content);
}
 
//пример вызова 
//проверьте доступно ли видео по ссылке, если нет, замените на другую ссылку, 
//ютуб не подойдет, т.к. там нужен API ключ
await LoadAndSaveVideoAsync("https://dsqqu7oxq6o1v.cloudfront.net/preview-9650dW8x3YLoZ8.mp4", "video.mp4");
 