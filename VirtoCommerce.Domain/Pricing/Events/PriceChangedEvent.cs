using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Pricing.Events
{
    public class PriceChangedEvent : GenericChangedEntryEvent<Model.Price>
    {
        public PriceChangedEvent(IEnumerable<GenericChangedEntry<Model.Price>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
