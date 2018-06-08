using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Commerce.Model
{
	[Flags]
	public enum AddressType
	{
		Billing = 1,
		Shipping = 2,
        Pickup = 4,
		BillingAndShipping = Billing | Shipping
	}
}
