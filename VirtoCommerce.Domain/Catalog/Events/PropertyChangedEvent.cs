using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class PropertyChangedEvent : GenericChangedEntryEvent<Model.Property>
    {
        public PropertyChangedEvent(IEnumerable<GenericChangedEntry<Model.Property>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
