using Grocery.Shared;

namespace Grocery.UI.Services;

public interface IDataService
{
    Task<List<WeatherForecastListItem?>> GetWeatherForecastsAsync();

    Task<WeatherForecastDetail?> GetWeatherForecastByIdAsync(int id);
    Task Create(WeatherForecastDetail item);
    Task Save(WeatherForecastDetail item);
    Task Delete(int id);
}