using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class CatalogChangingEvent : GenericChangedEntryEvent<Model.Catalog>
    {
        public CatalogChangingEvent(IEnumerable<GenericChangedEntry<Model.Catalog>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
