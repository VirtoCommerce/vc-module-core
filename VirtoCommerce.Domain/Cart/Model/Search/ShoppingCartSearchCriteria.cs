using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Cart.Model
{
    public class ShoppingCartSearchCriteria : SearchCriteriaBase
    {
        public string Name { get; set; }
        public string Keyword { get; set; }
        public string CustomerId { get; set; }
        public string StoreId { get; set; }
    }
}
