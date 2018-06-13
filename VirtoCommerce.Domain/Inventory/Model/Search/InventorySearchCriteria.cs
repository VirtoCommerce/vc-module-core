using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.Domain.Inventory.Model.Search
{
    public class InventorySearchCriteria : SearchCriteriaBase
    {
        public GeoPoint Location { get; set; }
        public IList<string> FulfillmentCenterIds { get; set; }
        public IList<string> ProductIds { get; set; }
    }
}
