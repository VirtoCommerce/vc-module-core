using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.Promotions.Search
{
    public class CouponSearchCriteria : SearchCriteriaBase
    {
        public string Code { get; set; }
        public string PromotionId { get; set; }
    }
}