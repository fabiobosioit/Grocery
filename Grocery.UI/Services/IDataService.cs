using Grocery.Shared;

namespace Grocery.UI.Services;

public interface IDataService<ListItemType, DetailsType, IdType>
{
    Task<List<ListItemType?>> GetAllItemsAsync();

    Task<DetailsType?> GetByIdAsync(IdType id);
    Task CreateAsync(DetailsType item);
    Task SaveAsync(DetailsType item);
    Task DeleteAsync(IdType id);
}       