using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.Promotions.Search
{
    public class PromotionUsageSearchCriteria : SearchCriteriaBase
    {
        public string CouponCode { get; set; }
        public string PromotionId { get; set; }
        public string ObjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
