using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Inventory.Model;
using VirtoCommerce.Domain.Inventory.Model.Search;

namespace VirtoCommerce.Domain.Inventory.Services
{
    public interface IFulfillmentCenterSearchService
    {
        GenericSearchResult<FulfillmentCenter> SearchCenters(FulfillmentCenterSearchCriteria criteria);
    }
}
