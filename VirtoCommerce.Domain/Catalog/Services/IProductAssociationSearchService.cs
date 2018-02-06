using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Catalog.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Services
{
    public interface IProductAssociationSearchService
    {
        SearchResult SearchProductAssociations(ProductAssociationSearchCriteria criteria);
    }
}
