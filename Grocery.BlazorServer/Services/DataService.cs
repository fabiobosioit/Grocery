using Grocery.UI.Services;
using Grocery.Shared;

namespace Grocery.BlazorServer.Services;

public class DataService:IDataService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<List<WeatherForecast>?> GetWeatherForecastAsync()
    {
        var res = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();

        return Task.FromResult(res)!;
    }
}