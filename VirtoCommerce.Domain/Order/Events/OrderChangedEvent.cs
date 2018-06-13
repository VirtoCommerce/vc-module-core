using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Order.Events
{
    public class OrderChangedEvent : GenericChangedEntryEvent<CustomerOrder>
    {
        public OrderChangedEvent(IEnumerable<GenericChangedEntry<CustomerOrder>> changedEntries)
       : base(changedEntries)
        {
        }
       
    }
}
