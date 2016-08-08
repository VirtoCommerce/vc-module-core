using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Pricing.Model.Search
{
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            Count = 20;
        }

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

        public string PriceListId { get; set; }

        private string[] _priceListIds;
        public string[] PriceListIds
        {
            get
            {
                if (_priceListIds == null && !string.IsNullOrEmpty(PriceListId))
                {
                    _priceListIds = new[] { PriceListId };
                }
                return _priceListIds;
            }
            set
            {
                _priceListIds = value;
            }
        }

        public int Start { get; set; }
        public int Count { get; set; }
    }
}
