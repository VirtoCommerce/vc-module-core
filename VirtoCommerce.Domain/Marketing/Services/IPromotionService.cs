using VirtoCommerce.Domain.Marketing.Model;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface IPromotionService
    {
        Promotion[] GetPromotionsByIds(string[] ids);
        void SavePromotions(Promotion[] promotions);
        void DeletePromotions(string[] ids);
    }
}