using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Inventory.Model;

namespace VirtoCommerce.Domain.Inventory.Events
{
    public class FulfillmentCenterChangingEvent : GenericChangedEntryEvent<FulfillmentCenter>
    {       
        public FulfillmentCenterChangingEvent(IEnumerable<GenericChangedEntry<FulfillmentCenter>> changedEntries)
           : base(changedEntries)
        {
        }
    }
}
