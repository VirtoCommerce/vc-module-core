using System.Collections.Generic;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Common.Events;

namespace VirtoCommerce.Domain.Cart.Events
{
    public class CartChangedEvent : GenericChangedEntryEvent<ShoppingCart>
    {       
        public CartChangedEvent(IEnumerable<GenericChangedEntry<ShoppingCart>> changedEntries)
          : base(changedEntries)
        {
        }      
    }
}
