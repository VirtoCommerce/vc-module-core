using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class PropertyChangingEvent : GenericChangedEntryEvent<Model.Property>
    {
        public PropertyChangingEvent(IEnumerable<GenericChangedEntry<Model.Property>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
