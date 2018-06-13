using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class CatalogChangedEvent : GenericChangedEntryEvent<Model.Catalog>
    {
        public CatalogChangedEvent(IEnumerable<GenericChangedEntry<Model.Catalog>> changedEntries)
            : base(changedEntries)
        {
        }        
    }
}
