using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Events
{
	public class OrderOperationChangeEvent
	{
		public OrderOperationChangeEvent(EntryState state, OrderOperation origOperation, OrderOperation modifiedOperation)
		{
			ChangeState = state;
            OrigOperation = origOperation;
            ModifiedOperation = modifiedOperation;
		}

		public EntryState ChangeState { get; set; }
		public OrderOperation OrigOperation { get; set; }
		public OrderOperation ModifiedOperation { get; set; }
	}
}
