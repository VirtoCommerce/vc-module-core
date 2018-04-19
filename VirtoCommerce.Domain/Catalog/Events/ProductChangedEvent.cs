using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class ProductChangedEvent : GenericChangedEntryEvent<Model.CatalogProduct>
    {
        public ProductChangedEvent(IEnumerable<GenericChangedEntry<Model.CatalogProduct>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
