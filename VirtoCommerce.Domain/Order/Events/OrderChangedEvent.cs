using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Events
{
    public class OrderChangedEvent : GenericChangedEntryEvent<CustomerOrder>
    {
        [Obsolete]
        public OrderChangedEvent(EntryState state, CustomerOrder oldOrder, CustomerOrder newOrder)
           : this(new[] { new GenericChangedEntry<CustomerOrder>(newOrder, oldOrder, state) })
        {
        }

        public OrderChangedEvent(IEnumerable<GenericChangedEntry<CustomerOrder>> changedEntries)
       : base(changedEntries)
        {
        }

        [Obsolete]
        public EntryState ChangeState => ChangedEntries.FirstOrDefault()?.EntryState ?? EntryState.Unchanged;
        [Obsolete]
        public CustomerOrder OrigOrder => ChangedEntries.FirstOrDefault()?.OldEntry;
        [Obsolete]
        public CustomerOrder ModifiedOrder => ChangedEntries.FirstOrDefault()?.NewEntry;
    }
}
