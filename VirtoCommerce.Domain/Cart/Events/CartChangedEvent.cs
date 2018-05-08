using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Events
{
    public class CartChangedEvent : GenericChangedEntryEvent<ShoppingCart>
    {
        public CartChangedEvent(EntryState state, ShoppingCart oldCart, ShoppingCart newCart)
           : this(new[] { new GenericChangedEntry<ShoppingCart>(newCart, oldCart, state) })
        {
        }

        public CartChangedEvent(IEnumerable<GenericChangedEntry<ShoppingCart>> changedEntries)
          : base(changedEntries)
        {
        }

        [Obsolete]
        public EntryState ChangeState => ChangedEntries.FirstOrDefault()?.EntryState ?? EntryState.Unchanged;
        [Obsolete]
        public ShoppingCart OrigCart => ChangedEntries.FirstOrDefault()?.OldEntry;
        [Obsolete]
        public ShoppingCart ModifiedCart => ChangedEntries.FirstOrDefault()?.NewEntry;
    }
}
