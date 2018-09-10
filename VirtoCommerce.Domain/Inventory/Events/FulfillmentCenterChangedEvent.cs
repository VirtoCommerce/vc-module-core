using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Inventory.Model;

namespace VirtoCommerce.Domain.Inventory.Events
{
    public class FulfillmentCenterChangedEvent : GenericChangedEntryEvent<FulfillmentCenter>
    {
        public FulfillmentCenterChangedEvent(IEnumerable<GenericChangedEntry<FulfillmentCenter>> changedEntries)
           : base(changedEntries)
        {
        }
    }
}
