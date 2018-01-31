using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Order.Services
{
    public interface ICustomerOrderService 
	{
        CustomerOrder[] GetByIds(string[] orderIds, string responseGroup = null);
        void SaveChanges(CustomerOrder[] orders);
        void Delete(string[] ids);
    }
}
