using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Inventory.Model
{
    public class FulfillmentCenter : AuditableEntity
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public string GeoLocation { get; set; }

        public Address Address { get; set; }
	}
}
