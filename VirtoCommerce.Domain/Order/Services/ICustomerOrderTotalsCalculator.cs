using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Order.Services
{
    public interface ICustomerOrderTotalsCalculator
    {
        void CalculateTotals(CustomerOrder order);
    }
}
