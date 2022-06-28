using Grocery.UI.Services;
using Grocery.Shared;

namespace Grocery.BlazorServer.Services;

public class Dataservice:IDataService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]?> GetWeatherForecastAsync()
    {
        var res = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();

        return Task.FromResult((WeatherForecast[]?)res);
    }
}