using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Catalog.Model.Search;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Services
{
    /// <summary>
    /// Represent abstraction for search property dictionary items  
    /// </summary>
    public interface IProperyDictionaryItemSearchService
    {
        GenericSearchResult<PropertyDictionaryItem> Search(PropertyDictionaryItemSearchCriteria searchCriteria);
    }
}
