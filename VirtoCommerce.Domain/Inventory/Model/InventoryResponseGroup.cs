using System;

namespace VirtoCommerce.Domain.Inventory.Model
{
    [Flags]
    public enum InventoryResponseGroup
    {
        None = 0,
        WithFulfillmentCenter = 1,
    }
}
