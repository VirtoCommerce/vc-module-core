using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Pricing.Model.Search
{
    public class PricingSearchResult<T>
    {
        public int TotalCount { get; set; }
        public ICollection<T> Results { get; set; }

    }
}
