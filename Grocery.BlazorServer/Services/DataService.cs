using Grocery.BlazorServer.Data;
using Grocery.Infrastructure;
using Grocery.UI.Services;
using Grocery.Shared;
using Microsoft.EntityFrameworkCore;

namespace Grocery.BlazorServer.Services;

public class DataService:IDataService
{
    private readonly IRepository<WeatherForecast,int> _repository;
    public DataService(IRepository<WeatherForecast,int> repository)
    {
        _repository = repository;
    }
    public Task<List<WeatherForecastListItem?>> GetWeatherForecastsAsync()
    {
        Task<List<WeatherForecastListItem?>> res = _repository.GetAll()
            .Select(element =>
                new WeatherForecastListItem()
                {
                    Id = element.Id,
                    Date = element.Date,
                    TemperatureC = element.TemperatureC
                }).ToListAsync<WeatherForecastListItem?>();

        return (res);
    }
    
    public async Task<WeatherForecastDetail?> GetWeatherForecastByIdAsync(int id)
    {
        var element = await _repository.GetByIdAsync(id);
        if (element != null)
        {
            return new WeatherForecastDetail()
            {
                Id = element.Id,
                Date = element.Date,
                TemperatureC = element.TemperatureC
            };
        }
        return null;
    }

    public Task Create(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };
        return _repository.Create(entity);
    }

    public  Task Save(WeatherForecastDetail item)
    {
        var entity = new WeatherForecast()
        {
            Id = item.Id,
            Date = DateTime.Now,
            Summary = item.Summary,
            TemperatureC = item.TemperatureC
        };

        return _repository.Update(entity);
        // await _dbContext.SaveChangesAsync();
        // _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public Task Delete(int id)
    {
        return _repository.Delete(id);
        // var entity = new WeatherForecast() { Id = id };
        // _dbContext.WeatherForecasts.Remove(entity);
        // return _dbContext.SaveChangesAsync();
    }
}