using System.Net;
using System.Net.Http.Json;
using Grocery.Shared;
using Grocery.UI.Services;

namespace Grocery.Client.Services;

public class Dataservice:IDataService
{
    private readonly HttpClient _httpClient;

    public Dataservice(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<WeatherForecast[]?> GetWeatherForecastAsync()
    {
        return await _httpClient.GetFromJsonAsync<WeatherForecast[]?>("WeatherForecast");
    }
}