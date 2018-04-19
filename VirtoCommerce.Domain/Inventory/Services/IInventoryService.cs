using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Inventory.Model;

namespace VirtoCommerce.Domain.Inventory.Services
{
	public interface IInventoryService
	{
        [Obsolete("Use VirtoCommerce.Domain.Inventory.Services.IInventorySearchService instead")]
	    IEnumerable<InventoryInfo> GetAllInventoryInfos();
        IEnumerable<InventoryInfo> GetProductsInventoryInfos(IEnumerable<string> productIds);
		InventoryInfo UpsertInventory(InventoryInfo inventoryInfo);
		void UpsertInventories(IEnumerable<InventoryInfo> inventoryInfos);
	}
}
