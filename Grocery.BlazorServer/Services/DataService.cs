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

    public Task Create(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };
        _dbContext.WeatherForecasts.Add(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task Save(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Id = item.Id,
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };

        _dbContext.WeatherForecasts.Update(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task Delete(int id)
    {
        var entity = new WeatherForecast() { Id = id };
        _dbContext.WeatherForecasts.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }
}