using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Catalog.Model.Search;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Services
{
    public interface IProductAssociationSearchService
    {
        GenericSearchResult<CatalogProduct> SearchProductAssociations(ProductAssociationSearchCriteria criteria);
    }
}
