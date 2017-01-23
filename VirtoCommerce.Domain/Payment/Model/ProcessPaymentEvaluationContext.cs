using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.Domain.Payment.Model
{
	public class ProcessPaymentEvaluationContext : PaymentEvaluationContextBase
    {
		public ProcessPaymentEvaluationContext()
		{
		}

		public ProcessPaymentEvaluationContext(PaymentIn payment)
		{
			this.Payment = payment;
		}

		public Store.Model.Store Store { get; set; }
		public BankCardInfo BankCardInfo { get; set; }
	}
}
