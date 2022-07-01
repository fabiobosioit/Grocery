using Grocery.UI.Services;
using Grocery.Shared;

namespace Grocery.BlazorServer.Services;

public class DataService:IDataService
{
    public Task<List<WeatherForecastListItem>?> GetWeatherForecastAsync()
    {
        var res = Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecastListItem
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55)
                }).ToList();

        return Task.FromResult(res)!;
    }
}