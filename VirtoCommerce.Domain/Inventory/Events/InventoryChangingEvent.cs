using System.Collections.Generic;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Inventory.Model;

namespace VirtoCommerce.Domain.Inventory.Events
{
    public class InventoryChangingEvent : GenericChangedEntryEvent<InventoryInfo>
    {       
        public InventoryChangingEvent(IEnumerable<GenericChangedEntry<InventoryInfo>> changedEntries)
           : base(changedEntries)
        {
        }
    }
}
