using System.Net;
using System.Net.Http.Json;
using Grocery.Shared;
using Grocery.UI.Services;

namespace Grocery.Client.Services;

public class DataService:IDataService
{
    private readonly HttpClient _httpClient;

    public DataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<WeatherForecastListItem?>> GetWeatherForecastsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<WeatherForecastListItem?>>("WeatherForecast");
    }

    public Task<WeatherForecastDetail?> GetWeatherForecastByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task Create(WeatherForecastDetail item)
    {
        throw new NotImplementedException();
    }

    public Task Save(WeatherForecastDetail item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}