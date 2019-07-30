using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Store.Model
{
    public class SearchCriteria : SearchCriteriaBase
    {
        public SearchCriteria()
        {
            Take = 20;
        }

        public string[] StoreIds { get; set; }
        public string Keyword { get; set; }
        public IList<StoreState> StoreStates { get; set; }
        public IList<string> FulfillmentCenterIds { get; set; }
    }
}
