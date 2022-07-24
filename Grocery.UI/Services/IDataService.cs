using Grocery.Infrastructure.DataTypes;

namespace Grocery.UI.Services;

public interface IDataService<ListItemType, DetailsType, IdType>
    where ListItemType : BaseListItem<IdType>
{
    Task<Page<ListItemType, IdType>> GetAllItemsAsync(PageParameters pageparameters);

    Task<DetailsType?> GetByIdAsync(IdType id);
    Task CreateAsync(DetailsType item);
    Task SaveAsync(DetailsType item);
    Task DeleteAsync(IdType id);
}       