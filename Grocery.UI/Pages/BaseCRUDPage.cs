using Grocery.Shared;
using Grocery.UI.Services;
using Microsoft.AspNetCore.Components;


namespace Grocery.UI.Pages
{
    public class BaseCRUDPage :ComponentBase
    {
        protected List<WeatherForecastListItem?>? _forecasts;
        protected WeatherForecastDetail? _selectedItem = null;

        [Inject] protected IDataService? _DataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (_DataService == null)
            {
                throw new Exception("DataService not inizitlized!!!");  //here the properties are already instanciated
            }
            await RefreshData();
        }

        protected async Task RefreshData()
        {
            _forecasts = await _DataService!.GetWeatherForecastsAsync();
        }

        protected void Create()
        {
            _selectedItem = new WeatherForecastDetail()
            {
                Date = new DateTime(),
                Summary = "n.a.",
                TemperatureC = 0
            };
        }

        protected async Task Edit(WeatherForecastListItem selected)
        {
            _selectedItem = await _DataService!.GetWeatherForecastByIdAsync(selected.Id);
            // RefreshData();
            // _selectedItem = null;
        }

        protected async Task SaveItem(WeatherForecastDetail item)
        {
            if (item.Id == 0)
            {
                await _DataService!.Create(item);
            }
            else
            {
                await _DataService!.Save(item);
            }
            await RefreshData();
            _selectedItem = null;
        }

        protected async Task Delete(WeatherForecastListItem selected)
        {
            // _forecasts?.Remove(selected);
            await _DataService!.Delete(selected.Id);
            await RefreshData();
            _selectedItem = null;
        }

        protected void Cancel()
        {
            _selectedItem = null;
        }
    }
}
