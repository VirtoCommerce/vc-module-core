using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class ProductChangingEvent : GenericChangedEntryEvent<Model.CatalogProduct>
    {
        public ProductChangingEvent(IEnumerable<GenericChangedEntry<Model.CatalogProduct>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
