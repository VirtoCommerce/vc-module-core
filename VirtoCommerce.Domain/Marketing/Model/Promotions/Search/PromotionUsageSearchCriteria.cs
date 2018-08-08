using System;
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
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
