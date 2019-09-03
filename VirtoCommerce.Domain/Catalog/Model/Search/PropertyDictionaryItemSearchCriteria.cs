using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    /// <summary>
    /// Search criteria used for search property dictionary items
    /// </summary>
    public class PropertyDictionaryItemSearchCriteria : SearchCriteriaBase
    {
        public IList<string> PropertyIds { get; set; }
    }
}
