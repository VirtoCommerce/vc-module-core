using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Order.Events
{
    public class OrderChangeEvent : GenericChangedEntryEvent<CustomerOrder>
    {
        public OrderChangeEvent(IEnumerable<GenericChangedEntry<CustomerOrder>> changedEntries)
           : base(changedEntries)
        {
        }
    }
}
