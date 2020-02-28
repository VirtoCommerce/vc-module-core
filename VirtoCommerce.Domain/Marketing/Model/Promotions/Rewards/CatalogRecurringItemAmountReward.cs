using System;

namespace VirtoCommerce.Domain.Marketing.Model
{
    public class CatalogRecurringItemAmountReward : CatalogItemAmountReward
    {
        public CatalogRecurringItemAmountReward()
            : base()
        {

        }

        protected CatalogRecurringItemAmountReward(CatalogRecurringItemAmountReward other)
            : base(other)
        {
            
        }

        public override PromotionReward Clone()
        {
            return new CatalogRecurringItemAmountReward(this);
        }
    }
}
