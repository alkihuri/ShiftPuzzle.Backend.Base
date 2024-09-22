using Microsoft.AspNetCore.Mvc;

namespace Practices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MultiApiController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public MultiApiController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<string> FetchDataFromApiAsync(string url)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            return $"Error fetching data from {url}: {ex.Message}";
        }
    }

    [HttpGet("fetch-multiple")]
    public async Task<IActionResult> FetchDataFromMultipleApis()
    {
        string weatherApiUrl = "https://api.weather.com/v3/weather/conditions";
        string currencyApiUrl = "https://api.currencyapi.com/v3/latest";
        string newsApiUrl = "https://api.newsapi.com/v3/top-headlines";

        // Запросы запускаются параллельно
        var weatherTask = FetchDataFromApiAsync(weatherApiUrl);
        var currencyTask = FetchDataFromApiAsync(currencyApiUrl);
        var newsTask = FetchDataFromApiAsync(newsApiUrl);

        // Ожидание завершения всех задач
        await Task.WhenAll(weatherTask, currencyTask, newsTask);

        // Формирование результата
        var result = new
        {
            Weather = weatherTask.Result,
            Currency = currencyTask.Result,
            News = newsTask.Result
        };

        return Ok(result);
    }
}