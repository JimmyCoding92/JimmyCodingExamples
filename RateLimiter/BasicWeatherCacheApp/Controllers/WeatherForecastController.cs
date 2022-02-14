using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BasicWeatherCacheApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly HttpClient _client;
    private readonly IDatabase _redis;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory, IConnectionMultiplexer muxer)
    {
        _logger = logger;
        _client = httpClientFactory.CreateClient("weatherclient");
        _redis = muxer.GetDatabase();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ForecastResult> Get([FromQuery] double latitude, [FromQuery] double longitude)
    {
        string json;
        var watch = Stopwatch.StartNew();
        var keyName = $"forecast:{latitude},{longitude}";
        json = await _redis.StringGetAsync(keyName);
        if (string.IsNullOrEmpty(json))
        {
            json = await GetForecast(latitude, longitude);
            var setTask = _redis.StringSetAsync(keyName, json);
            var expireTask = _redis.KeyExpireAsync(keyName, TimeSpan.FromSeconds(3600));
            await Task.WhenAll(setTask, expireTask);
        }

        var forecast =
            JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(json);
        watch.Stop();
        var result = new ForecastResult(forecast, watch.ElapsedMilliseconds);

        return result;
    }

    private async Task<string> GetForecast(double latitude, double longitude)
    {
        var pointsRequestQuery = $"https://api.weather.gov/points/{latitude},{longitude}"; //get the URI
        var result = await _client.GetFromJsonAsync<JsonObject>(pointsRequestQuery);
        var gridX = result["properties"]["gridX"].ToString();
        var gridY = result["properties"]["gridY"].ToString();
        var gridId = result["Properties"]["gridId"].ToString();
        var forecastRequestQuery = $"https://api.weather.gov/gridpoints/{gridId}/{gridX},{gridY}/forecast";
        var forecastResult = await _client.GetFromJsonAsync<JsonObject>(forecastRequestQuery);
        var periodsJson = forecastResult["properties"]["periods"].ToJsonString();
        return periodsJson;
    }
}
