using System.Net;
using System.Net.Http.Json;
using Grocery.Infrastructure.DataTypes;
using Grocery.Shared;
using Grocery.UI.Services;

namespace Grocery.Client.Services;

public class DataService<ListItemType, DetailsType, IdType> : IDataService<ListItemType, DetailsType, IdType>
    where DetailsType:BaseDetails<IdType>
    where ListItemType : BaseListItem<IdType>
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public DataService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        this._configuration = configuration;
    }
    public async Task<Page<ListItemType, IdType>> GetAllItemsAsync(PageParameters pageParameters)
    {
        var baseUrl = this.getBaseurl<ListItemType>();
        return await _httpClient.GetFromJsonAsync<Page<ListItemType,IdType>>(
            $"{baseUrl}?OrderBy={pageParameters.OrderBy}&OrderByDirection={pageParameters.OrderByDirection}&Page={pageParameters.Page}&FilterText={pageParameters.FilterText}")!;
    }

    public Task<DetailsType?> GetByIdAsync(IdType id)
    {
        var baseUrl = this.getBaseurl<DetailsType>();
        return _httpClient.GetFromJsonAsync<DetailsType?>($"{baseUrl}/{id}");
    }

    public Task CreateAsync(DetailsType item)
    {
        var baseUrl = this.getBaseurl<DetailsType>();
        return _httpClient.PostAsJsonAsync<DetailsType?>($"{baseUrl}", item);
    }

    public Task SaveAsync(DetailsType item)
    {
        var baseUrl = this.getBaseurl<DetailsType>();
        return _httpClient.PutAsJsonAsync<DetailsType?>($"{baseUrl}/{item.Id}", item);
    }

    public Task DeleteAsync(IdType id)
    {
        var baseurl = this.getBaseurl<DetailsType>();
        
        return _httpClient.DeleteAsync($"WeatherForecast/{id}");

    }

    private string getBaseurl<T>()
    {
        var baseUrl = this._configuration[$"ApiUrls:{typeof(T).Name}"];
        if (baseUrl == null)
        {
            //baseurl = typeof(DetailsType).Name; 
            //oppure
            throw new Exception($"ApiUrls:{typeof(T).Name} not implemented");
        }
        return baseUrl;
    }

}