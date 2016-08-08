using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Pricing.Model.Search
{
    public class SearchResult
    {
        public SearchResult()
        {
            Prices = new List<Price>();
        }

        public int TotalCount { get; set; }

        public List<Price> Prices { get; set; }

    }
}
