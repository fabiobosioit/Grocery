using System.Net;
using System.Net.Http.Json;
using Grocery.Infrastructure.DataTypes;
using Grocery.Shared;
using Grocery.UI.Services;

namespace Grocery.Client.Services;

public class DataService<ListItemType, DetailsType, IdType> : IDataService<ListItemType, DetailsType, IdType>
    where DetailsType:BaseDetails<IdType>
{
    private readonly HttpClient _httpClient;

    public DataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ListItemType?>> GetAllItemsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ListItemType?>>("WeatherForecast");
    }

    public Task<DetailsType?> GetByIdAsync(IdType id)
    {
        return _httpClient.GetFromJsonAsync<DetailsType?>($"WeatherForecast/{id}");
    }

    public Task CreateAsync(DetailsType item)
    {
        return _httpClient.PostAsJsonAsync<DetailsType?>($"WeatherForecast", item);
    }

    public Task SaveAsync(DetailsType item)
    {
        return _httpClient.PutAsJsonAsync<DetailsType?>($"WeatherForecast/{item.Id}", item);
    }

    public Task DeleteAsync(IdType id)
    {
        return _httpClient.DeleteAsync($"WeatherForecast/{id}");

    }


}