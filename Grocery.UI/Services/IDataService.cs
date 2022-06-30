using Grocery.Shared;

namespace Grocery.UI.Services;

public interface IDataService
{
    Task<WeatherForecast[]?> GetWeatherForecastAsync();
    
}