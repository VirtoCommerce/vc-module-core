using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace VirtoCommerce.Domain.Marketing.Model
{
    public class CartSubtotalReward : AmountBasedReward
    {
        public CartSubtotalReward()
        {
        }
        //Copy constructor
        protected CartSubtotalReward(CartSubtotalReward other)
            : base(other)
        {
            Amount = other.Amount;
        }

        public override PromotionReward Clone()
        {
            return new CartSubtotalReward(this);
        }
    }
}
