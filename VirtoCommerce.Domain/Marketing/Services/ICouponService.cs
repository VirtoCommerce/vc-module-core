using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Domain.Marketing.Model.Promotions;
using VirtoCommerce.Domain.Marketing.Model.Promotions.Search;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface ICouponService
    {
        GenericSearchResult<Model.Coupon> SearchCoupons(CouponSearchCriteria criteria);
        Model.Coupon[] GetByIds(string[] ids);
        void SaveCoupons(Model.Coupon[] coupons);
        void DeleteCoupons(string[] ids);
    }
}