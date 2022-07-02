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
        Task<List<WeatherForecastListItem?>> res = _dbContext.WeatherForecasts
            .AsNoTracking()
            .Select(element =>
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

    public async Task Create(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };
        _dbContext.WeatherForecasts.Add(entity);
        await _dbContext.SaveChangesAsync();
        _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task Save(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Id = item.Id,
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };

        _dbContext.WeatherForecasts.Update(entity);
        await _dbContext.SaveChangesAsync();
        _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public Task Delete(int id)
    {
        var entity = new WeatherForecast() { Id = id };
        _dbContext.WeatherForecasts.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }
}