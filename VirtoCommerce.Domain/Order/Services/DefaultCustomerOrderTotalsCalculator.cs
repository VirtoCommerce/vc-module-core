using System;
using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Services
{
    public class DefaultShopingCartTotalsCalculator : ICustomerOrderTotalsCalculator
    {
        /// <summary>
        /// Order subtotal discount
        /// When a discount is applied to the cart subtotal, the tax calculation has already been applied, and is reflected in the tax subtotal.
        /// Therefore, a discount applying to the cart subtotal will occur after tax.
        /// For instance, if the cart subtotal is $100, and $15 is the tax subtotal, a cart - wide discount of 10 % will yield a total of $105($100 subtotal – $10 discount + $15 tax on the original $100).
        /// </summary>
        public virtual void CalculateTotals(CustomerOrder order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            //Calculate totals for line items
            if (!order.Items.IsNullOrEmpty())
            {
                foreach (var item in order.Items)
                {
                    CalculateLineItemTotals(item);
                }
            }
            //Calculate totals for shipments
            if (!order.Shipments.IsNullOrEmpty())
            {
                foreach (var shipment in order.Shipments)
                {
                    CalculateShipmentTotals(shipment);
                }
            }
            //Calculate totals for payments
            if (!order.InPayments.IsNullOrEmpty())
            {
                foreach (var payment in order.InPayments)
                {
                    CalculatePaymentTotals(payment);
                }
            }

            order.DiscountTotal = 0m;
            order.DiscountTotalWithTax = 0m;
            order.FeeTotal = order.Fee;
            order.TaxTotal = 0m;

            if (!order.Items.IsNullOrEmpty())
            {
                order.SubTotal = order.Items.Sum(x => x.Price * x.Quantity);
                order.SubTotalWithTax = order.Items.Sum(x => x.PriceWithTax * x.Quantity);
                order.SubTotalDiscount = order.Items.Sum(x => x.DiscountTotal);
                order.SubTotalDiscountWithTax = order.Items.Sum(x => x.DiscountTotalWithTax);
                order.DiscountTotal += order.Items.Sum(x => x.DiscountTotal);
                order.DiscountTotalWithTax += order.Items.Sum(x => x.DiscountTotalWithTax);
                order.FeeTotal += order.Items.Sum(x => x.Fee);
                order.FeeTotalWithTax += order.Items.Sum(x => x.FeeWithTax);
                order.TaxTotal += order.Items.Sum(x => x.TaxTotal);
            }

            if (!order.Shipments.IsNullOrEmpty())
            {
                order.ShippingTotal = order.Shipments.Sum(x => x.Total);
                order.ShippingTotalWithTax = order.Shipments.Sum(x => x.TotalWithTax);
                order.ShippingSubTotal = order.Shipments.Sum(x => x.Price);
                order.ShippingSubTotalWithTax = order.Shipments.Sum(x => x.PriceWithTax);
                order.ShippingDiscountTotal = order.Shipments.Sum(x => x.DiscountAmount);
                order.ShippingDiscountTotalWithTax = order.Shipments.Sum(x => x.DiscountAmountWithTax);
                order.DiscountTotal += order.Shipments.Sum(x => x.DiscountAmount);
                order.DiscountTotalWithTax += order.Shipments.Sum(x => x.DiscountAmountWithTax);
                order.FeeTotal += order.Shipments.Sum(x => x.Fee);
                order.FeeTotalWithTax += order.Shipments.Sum(x => x.FeeWithTax);
                order.TaxTotal += order.Shipments.Sum(x => x.TaxTotal);
            }

            if (!order.InPayments.IsNullOrEmpty())
            {
                order.PaymentTotal = order.InPayments.Sum(x => x.Total);
                order.PaymentTotalWithTax = order.InPayments.Sum(x => x.TotalWithTax);
                order.PaymentSubTotal = order.InPayments.Sum(x => x.Price);
                order.PaymentSubTotalWithTax = order.InPayments.Sum(x => x.PriceWithTax);
                order.PaymentDiscountTotal = order.InPayments.Sum(x => x.DiscountAmount);
                order.PaymentDiscountTotalWithTax = order.InPayments.Sum(x => x.DiscountAmountWithTax);
                order.DiscountTotal += order.InPayments.Sum(x => x.DiscountAmount);
                order.DiscountTotalWithTax += order.InPayments.Sum(x => x.DiscountAmountWithTax);
                order.TaxTotal += order.InPayments.Sum(x => x.TaxTotal);
            }
            order.DiscountTotalWithTax = order.DiscountAmount + order.DiscountAmount * order.TaxPercentRate;
            order.FeeTotalWithTax = order.Fee + order.Fee * order.TaxPercentRate;
            order.DiscountTotal += order.DiscountAmount;
            order.DiscountTotalWithTax += order.DiscountTotalWithTax;
            //Subtract from cart tax total self discount tax amount
            order.TaxTotal -= order.DiscountTotalWithTax - order.DiscountAmount;
            order.Total = order.SubTotal + order.ShippingSubTotal + order.TaxTotal + order.PaymentSubTotal + order.FeeTotal - order.DiscountTotal;
        }

        protected virtual void CalculatePaymentTotals(Model.PaymentIn payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            payment.Total = payment.Price - payment.DiscountAmount;
            payment.PriceWithTax = payment.Price + payment.Price * payment.TaxPercentRate;
            payment.TotalWithTax = payment.PriceWithTax - payment.DiscountAmountWithTax;
            payment.DiscountAmountWithTax = payment.DiscountAmount + payment.DiscountAmount * payment.TaxPercentRate;
            payment.TaxTotal = payment.TotalWithTax - payment.Total;
        }

        protected virtual void CalculateShipmentTotals(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException(nameof(shipment));
            }
            shipment.PriceWithTax = shipment.Price + shipment.Price * shipment.TaxPercentRate;
            shipment.DiscountAmountWithTax = shipment.DiscountAmount + shipment.DiscountAmount * shipment.TaxPercentRate;
            shipment.FeeWithTax = shipment.Fee + shipment.Fee * shipment.TaxPercentRate;
            shipment.Total = shipment.Price + shipment.Fee - shipment.DiscountAmount;
            shipment.TotalWithTax = shipment.PriceWithTax + shipment.FeeWithTax - shipment.DiscountAmountWithTax;
            shipment.TaxTotal = shipment.TotalWithTax - shipment.Total;
        }

        protected virtual void CalculateLineItemTotals(LineItem lineItem)
        {
            if (lineItem == null)
            {
                throw new ArgumentNullException(nameof(lineItem));
            }
            lineItem.PriceWithTax = lineItem.Price + lineItem.Price * lineItem.TaxPercentRate;
            lineItem.PlacedPrice = lineItem.Price - lineItem.DiscountAmount;
            lineItem.ExtendedPrice = lineItem.PlacedPrice * lineItem.Quantity;
            lineItem.DiscountAmountWithTax = lineItem.DiscountAmount + lineItem.DiscountAmount * lineItem.TaxPercentRate;
            lineItem.DiscountTotal = lineItem.DiscountAmount * Math.Max(1, lineItem.Quantity);
            lineItem.FeeWithTax = lineItem.Fee + lineItem.Fee * lineItem.TaxPercentRate;
            lineItem.PlacedPriceWithTax = lineItem.PlacedPrice + lineItem.PlacedPrice * lineItem.TaxPercentRate;
            lineItem.ExtendedPriceWithTax = lineItem.PlacedPriceWithTax * lineItem.Quantity;
            lineItem.DiscountTotalWithTax = lineItem.DiscountAmountWithTax * Math.Max(1, lineItem.Quantity);
            lineItem.TaxTotal = lineItem.ExtendedPriceWithTax - lineItem.ExtendedPrice + lineItem.FeeWithTax - lineItem.Fee;
        }
    }
}
