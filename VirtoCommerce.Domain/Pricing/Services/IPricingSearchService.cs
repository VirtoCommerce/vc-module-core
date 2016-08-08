using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Pricing.Model.Search;

namespace VirtoCommerce.Domain.Pricing.Services
{
    public interface IPricingSearchService
    {
        SearchResult Search(SearchCriteria criteria);
    }
}
