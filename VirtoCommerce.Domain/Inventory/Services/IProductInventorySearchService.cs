using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Inventory.Model;
using VirtoCommerce.Domain.Inventory.Model.Search;

namespace VirtoCommerce.Domain.Inventory.Services
{
    /// <summary>
    /// This interface is intended to search  the product inventories within all fulfillment centers, do a LeftJoin search with fulfillment centers and return  InventoryInfo
    /// object for each Fulfillment center registered in the system even if it won't have an inventory record for a given product 
    /// </summary>
    public interface IProductInventorySearchService
    {
        GenericSearchResult<InventoryInfo> SearchProductInventories(ProductInventorySearchCriteria criteria);
    }
}
