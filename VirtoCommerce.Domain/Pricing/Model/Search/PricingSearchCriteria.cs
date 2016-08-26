using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Pricing.Model.Search
{
    public class PricingSearchCriteria
    {
        public PricingSearchCriteria()
        {
            Take = 20;
        }

    
        public string Keyword { get; set; }

        /// <summary>
        /// Sorting expression property1:asc;property2:desc
        /// </summary>
        public string Sort { get; set; }

        public SortInfo[] SortInfos
        {
            get
            {
                return SortInfo.Parse(Sort).ToArray();
            }
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
