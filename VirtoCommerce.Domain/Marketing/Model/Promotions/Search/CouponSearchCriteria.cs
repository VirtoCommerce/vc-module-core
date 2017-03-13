using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.Promotions.Search
{
    public class CouponSearchCriteria : SearchCriteriaBase
    {
        public string Keyword { get; set; }

        public bool? IsActive { get; set; }
    }
}