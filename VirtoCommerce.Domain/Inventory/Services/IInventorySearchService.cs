using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Inventory.Model;
using VirtoCommerce.Domain.Inventory.Model.Search;

namespace VirtoCommerce.Domain.Inventory.Services
{
    public interface IInventorySearchService
    {
        GenericSearchResult<InventoryInfo> SearchInventories(InventorySearchCriteria criteria);
    }
}
