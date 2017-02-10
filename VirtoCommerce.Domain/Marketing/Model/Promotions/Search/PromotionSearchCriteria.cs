using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.Promotions.Search
{
    public class PromotionSearchCriteria : SearchCriteriaBase
    {
        public string Keyword { get; set; }
        public bool OnlyActive { get; set; }
        public string Store { get; set; }
    }
}
