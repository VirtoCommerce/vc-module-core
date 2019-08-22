using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Domain.Pricing.Model.Search;

namespace VirtoCommerce.Domain.Pricing.Services
{
    public interface IPricingSearchService
    {
        PricingSearchResult<Price> SearchPrices(PricesSearchCriteria criteria);
        PricingSearchResult<Pricelist> SearchPricelists(PricelistSearchCriteria criteria);
        PricingSearchResult<PricelistAssignment> SearchPricelistAssignments(PricelistAssignmentsSearchCriteria criteria);
    }
}
