using Grocery.BlazorServer.Data;
using Grocery.UI.Services;
using Grocery.Shared;
using Microsoft.EntityFrameworkCore;

namespace Grocery.BlazorServer.Services;

public class DataService:IDataService
{
    private readonly WeatherForecastContext _dbContext;

    public DataService(WeatherForecastContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<List<WeatherForecastListItem?>> GetWeatherForecastsAsync()
    {
        Task<List<WeatherForecastListItem?>> res = _dbContext.WeatherForecasts.Select(element =>
            new WeatherForecastListItem()
            {
                Id = element.Id,
                Date = element.Date,
                TemperatureC = element.TemperatureC
            }).ToListAsync<WeatherForecastListItem?>();

        return (res);
    }
    
    public Task<WeatherForecastDetail?> GetWeatherForecastByIdAsync(int id)
    {
        return _dbContext.WeatherForecasts
            .Where(x => x.Id == id)
            .Select(element => new WeatherForecastDetail()
            {
                Id = element.Id,
                Date = element.Date,
                TemperatureC = element.TemperatureC
            }).SingleOrDefaultAsync();
    }


}