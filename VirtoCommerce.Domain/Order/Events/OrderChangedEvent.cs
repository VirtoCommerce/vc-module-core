using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Events
{
    public class OrderChangedEvent
    {
        public OrderChangedEvent(EntryState state, CustomerOrder origOrder, CustomerOrder modifiedOrder)
        {
            ChangeState = state;
            OrigOrder = origOrder;
            ModifiedOrder = modifiedOrder;
        }

        public EntryState ChangeState { get; set; }
        public CustomerOrder OrigOrder { get; set; }
        public CustomerOrder ModifiedOrder { get; set; }

        public bool IsOrderNowPaid()
        {
            var retVal = false;

            if (OrigOrder != null && ModifiedOrder != null)
            {
                foreach (var origPayment in OrigOrder.InPayments)
                {
                    var modifiedPayment = ModifiedOrder.InPayments.FirstOrDefault(i => i.Id == origPayment.Id);
                    if (modifiedPayment != null)
                    {
                        var paidSum = ModifiedOrder.InPayments.Where(i => i.PaymentStatus == PaymentStatus.Paid)
                            .Sum(i => i.Sum);
                        retVal = modifiedPayment.PaymentStatus == PaymentStatus.Paid &&
                                 origPayment.PaymentStatus != PaymentStatus.Paid && paidSum == ModifiedOrder.Total;
                    }

                    if (retVal)
                    {
                        break;
                    }
                }
            }

            return retVal;
        }
    }
}
