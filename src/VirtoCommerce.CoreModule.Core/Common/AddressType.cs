using System;

namespace VirtoCommerce.CoreModule.Core.Common
{
    [Flags]
    public enum AddressType
    {
        Undefined = 0,
        Billing = 1,
        Shipping = 2,
        Pickup = 4,
        BillingAndShipping = Billing | Shipping
    }
}
