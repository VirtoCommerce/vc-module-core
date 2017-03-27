using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Events
{
    public class OrderChangedEvent
    {
        public OrderChangedEvent(EntryState state, CustomerOrder origOrder, CustomerOrder modifiedOrder)
        {
            ChangeState = state;
            OrigOrder = origOrder;
            ModifiedOrder = modifiedOrder;
        }

        public EntryState ChangeState { get; set; }
        public CustomerOrder OrigOrder { get; set; }
        public CustomerOrder ModifiedOrder { get; set; }
    }
}
