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

        GenericSearchResult<Coupon> SearchCoupons(CouponSearchCriteria criteria);
        void SaveCoupons(Coupon[] coupons);
        void DeleteCoupons(string[] ids);
    }
}