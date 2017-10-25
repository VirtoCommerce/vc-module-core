using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace VirtoCommerce.Domain.Marketing.Model
{
    /// <summary>
    /// Payment reward
    /// </summary>
    public class PaymentReward : AmountBasedReward
    {
        public PaymentReward()
        {
        }
        //Copy constructor
        protected PaymentReward(PaymentReward other)
            : base(other)
        {
            PaymentMethod = other.PaymentMethod;
        }
        public string PaymentMethod { get; set; }

        public override PromotionReward Clone()
        {
            return new PaymentReward(this);
        }
    }
}
