using System.Collections.Generic;
using VirtoCommerce.Domain.Inventory.Model;

namespace VirtoCommerce.Domain.Inventory.Services
{
    public interface IFulfillmentCenterService
    {
        void SaveChanges(IEnumerable<FulfillmentCenter> fulfillmentCenters);
        IEnumerable<FulfillmentCenter> GetByIds(IEnumerable<string> ids, string responseGroup = null);
        void Delete(IEnumerable<string> ids);
    }
}
