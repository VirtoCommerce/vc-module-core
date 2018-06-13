using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Pricing.Events
{
    public class PriceChangingEvent : GenericChangedEntryEvent<Model.Price>
    {
        public PriceChangingEvent(IEnumerable<GenericChangedEntry<Model.Price>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
