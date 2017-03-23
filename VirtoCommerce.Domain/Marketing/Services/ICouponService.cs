using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Marketing.Model.Promotions;
using VirtoCommerce.Domain.Marketing.Model.Promotions.Search;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface ICouponService
    {
        GenericSearchResult<Model.Coupon> SearchCoupons(CouponSearchCriteria criteria);

        Model.Coupon GetByCode(string promotionId, string code);

        void SaveCoupons(Model.Coupon[] coupons);

        void DeleteCoupons(string[] ids);

        void ClearCoupons(string promotionId);

        bool CheckCoupon(string couponCode, string promotionId);

        void ApplyCouponUsage(ApplyCouponRequest request);

        void RemoveCouponUsage(ApplyCouponRequest request);
    }
}