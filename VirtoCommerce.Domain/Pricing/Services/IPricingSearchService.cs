using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Domain.Pricing.Model.Search;

namespace VirtoCommerce.Domain.Pricing.Services
{
    public interface IPricingSearchService
    {
        PricingSearchResult<Price> SearchPrices(PricesSearchCriteria criteria);
        PricingSearchResult<Pricelist> SearchPricelists(PricingSearchCriteria criteria);
        PricingSearchResult<PricelistAssignment> SearchPricelistAssignments(PricingSearchCriteria criteria);
    }
}
