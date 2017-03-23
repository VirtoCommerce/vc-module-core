using VirtoCommerce.Domain.Marketing.Model;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface IPromotionService
    {
        Promotion[] GetActivePromotions();

        Promotion GetPromotionById(string id);
        Promotion CreatePromotion(Promotion promotion);
        void UpdatePromotions(Promotion[] prmotions);
        void DeletePromotions(string[] ids);
    }
}