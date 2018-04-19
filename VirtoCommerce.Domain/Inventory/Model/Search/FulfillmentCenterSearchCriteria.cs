using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.Domain.Inventory.Model.Search
{
    public class FulfillmentCenterSearchCriteria : SearchCriteriaBase
    {
        public GeoPoint Location { get; set; }
    }
}
