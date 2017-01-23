using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Payment.Model
{
    public abstract class PaymentEvaluationContextBase : IEvaluationContext
    {
        public PaymentIn Payment { get; set; }
        public CustomerOrder Order { get; set; }
        public NameValueCollection Parameters { get; set; }
    }
}
