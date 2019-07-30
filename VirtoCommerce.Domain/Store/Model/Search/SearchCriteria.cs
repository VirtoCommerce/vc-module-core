using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Store.Model
{
    public class SearchCriteria : SearchCriteriaBase
    {
        public SearchCriteria()
        {
            Take = 20;
        }

        public string Keyword { get; set; }
        public string[] StoreIds { get; set; }
        public StoreState[] StoreStates { get; set; }
        public string[] FulfillmentCenterIds { get; set; }
    }
}
