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
            Take = 20;
        }

        //Apply paginate limits to product count instead prices record
        public bool GroupByProducts { get; set; }

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

        public string ProductId { get; set; }

        private string[] _productIds;
        public string[] ProductIds
        {
            get
            {
                if (_productIds == null && !string.IsNullOrEmpty(ProductId))
                {
                    _productIds = new[] { ProductId };
                }
                return _productIds;
            }
            set
            {
                _productIds = value;
            }
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
