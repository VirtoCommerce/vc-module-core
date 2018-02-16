using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Order.Services
{
    public interface ICustomerOrderSearchService
	{
        GenericSearchResult<CustomerOrder> SearchCustomerOrders(CustomerOrderSearchCriteria criteria);
	}
}
