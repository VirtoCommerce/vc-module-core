using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Catalog.Events
{
    public class CategoryChangedEvent : GenericChangedEntryEvent<Model.Category>
    {
        public CategoryChangedEvent(IEnumerable<GenericChangedEntry<Model.Category>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
