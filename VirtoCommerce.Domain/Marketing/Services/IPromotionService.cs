using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Domain.Marketing.Model.Promotions.Search;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface IPromotionService
    {
        Promotion[] GetActivePromotions();

        Promotion GetPromotionById(string id);
        Promotion CreatePromotion(Promotion promotion);
        void UpdatePromotions(Promotion[] prmotions);
        void DeletePromotions(string[] ids);

        Coupon GetCouponById(string id);
        Coupon[] GetPersonalCoupons(string customerId);

        GenericSearchResult<Coupon> Search(CouponSearchCriteria criteria);
        void SaveCoupons(Coupon[] coupon);
        void DeleteCoupons(string[] ids);
    }
}