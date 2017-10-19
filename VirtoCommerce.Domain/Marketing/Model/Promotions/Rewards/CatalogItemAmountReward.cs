using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace VirtoCommerce.Domain.Marketing.Model
{
	
	public class CatalogItemAmountReward : AmountBasedReward
	{
		public CatalogItemAmountReward()
		{
		}
		//Copy constructor
		protected CatalogItemAmountReward(CatalogItemAmountReward other)
			: base(other)
		{
			ProductId = other.ProductId;
		}

		public string ProductId { get; set; }

		public override PromotionReward Clone()
		{
			return new CatalogItemAmountReward(this);
		}
	}
}
