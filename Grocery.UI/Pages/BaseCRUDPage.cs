using Grocery.Infrastructure.DataTypes;
using Grocery.UI.Services;
using Microsoft.AspNetCore.Components;


namespace Grocery.UI.Pages
{
    public class BaseCRUDPage<ListItemType,DetailsType, IdType> : ComponentBase
        where ListItemType : BaseListItem<IdType>
        where DetailsType : BaseDetails<IdType>, new()
    {
        protected List<ListItemType?>? _items;
        protected DetailsType? _selectedItem = null;

        [Inject] protected IDataService<ListItemType, DetailsType, IdType>? _DataService { get; set; }
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
            _items = await _DataService!.GetAllItemsAsync();
        }

        protected void Create()
        {
            _selectedItem = new DetailsType();
            //{
            //    Date = new DateTime(),
            //    Summary = "n.a.",
            //    TemperatureC = 0
            //};
        }

        protected async Task Edit(ListItemType selected)
        {
            if (selected.Id == null) throw new ArgumentException("Item cannot be null");
            _selectedItem = await _DataService!.GetByIdAsync(selected.Id);
            // RefreshData();
            // _selectedItem = null;
        }

        protected async Task SaveItem(DetailsType item)
        {
            //if (item.Id!= null && item.Id.Equals( default(IdType)))
            if (EqualityComparer<IdType>.Default.Equals(item.Id, default(IdType)))
            {
                await _DataService!.CreateAsync(item);
            }
            else
            {
                await _DataService!.SaveAsync(item);
            }
            await RefreshData();
            _selectedItem = null;
        }

        protected async Task Delete(ListItemType selectedItem)
        {
            if (selectedItem.Id == null) throw new ArgumentException("Item cannot be null");
            // _forecasts?.Remove(selected);
            await _DataService!.DeleteAsync(selectedItem.Id);
            await RefreshData();
            _selectedItem = null;
        }

        protected void Cancel()
        {
            _selectedItem = null;
        }
    }
}
