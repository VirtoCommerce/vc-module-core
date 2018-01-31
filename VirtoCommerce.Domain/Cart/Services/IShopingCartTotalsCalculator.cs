using VirtoCommerce.Domain.Cart.Model;

namespace VirtoCommerce.Domain.Cart.Services
{
    public interface IShopingCartTotalsCalculator
    {
        void CalculateTotals(ShoppingCart cart);
    }
}
