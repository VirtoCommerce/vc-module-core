using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Services
{
    public class DefaultShopingCartTotalsCalculator : IShopingCartTotalsCalculator
    {
        /// <summary>
        /// Cart subtotal discount
        /// When a discount is applied to the cart subtotal, the tax calculation has already been applied, and is reflected in the tax subtotal.
        /// Therefore, a discount applying to the cart subtotal will occur after tax.
        /// For instance, if the cart subtotal is $100, and $15 is the tax subtotal, a cart - wide discount of 10 % will yield a total of $105($100 subtotal – $10 discount + $15 tax on the original $100).
        /// </summary>
        public virtual void CalculateTotals(ShoppingCart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            //Calculate totals for line items
            if (!cart.Items.IsNullOrEmpty())
            {
                foreach (var item in cart.Items)
                {
                    CalculateLineItemTotals(item);
                }
            }
            //Calculate totals for shipments
            if (!cart.Shipments.IsNullOrEmpty())
            {
                foreach (var shipment in cart.Shipments)
                {
                    CalculateShipmentTotals(shipment);
                }
            }
            //Calculate totals for payments
            if (!cart.Payments.IsNullOrEmpty())
            {
                foreach (var payment in cart.Payments)
                {
                    CalculatePaymentTotals(payment);
                }
            }

            cart.DiscountTotal = 0m;
            cart.DiscountTotalWithTax = 0m;
            cart.FeeTotal = cart.Fee;
            cart.TaxTotal = 0m;

            if (!cart.Items.IsNullOrEmpty())
            {
                cart.SubTotal = cart.Items.Sum(x => x.ListPrice * x.Quantity);
                cart.SubTotalWithTax = cart.Items.Sum(x => x.ListPriceWithTax * x.Quantity);
                cart.SubTotalDiscount = cart.Items.Sum(x => x.DiscountTotal);
                cart.SubTotalDiscountWithTax = cart.Items.Sum(x => x.DiscountTotalWithTax);
                cart.DiscountTotal += cart.Items.Sum(x => x.DiscountTotal);
                cart.DiscountTotalWithTax += cart.Items.Sum(x => x.DiscountTotalWithTax);
                cart.FeeTotal += cart.Items.Sum(x => x.Fee);
                cart.FeeTotalWithTax += cart.Items.Sum(x => x.FeeWithTax);
                cart.TaxTotal += cart.Items.Sum(x => x.TaxTotal);
            }

            if (!cart.Shipments.IsNullOrEmpty())
            {
                cart.ShippingTotal = cart.Shipments.Sum(x => x.Total);
                cart.ShippingTotalWithTax = cart.Shipments.Sum(x => x.TotalWithTax);
                cart.ShippingSubTotal = cart.Shipments.Sum(x => x.Price);
                cart.ShippingSubTotalWithTax = cart.Shipments.Sum(x => x.PriceWithTax);
                cart.ShippingDiscountTotal = cart.Shipments.Sum(x => x.DiscountAmount);
                cart.ShippingDiscountTotalWithTax = cart.Shipments.Sum(x => x.DiscountAmountWithTax);
                cart.DiscountTotal += cart.Shipments.Sum(x => x.DiscountAmount);
                cart.DiscountTotalWithTax += cart.Shipments.Sum(x => x.DiscountAmountWithTax);
                cart.FeeTotal += cart.Shipments.Sum(x => x.Fee);
                cart.FeeTotalWithTax += cart.Shipments.Sum(x => x.FeeWithTax);
                cart.TaxTotal += cart.Shipments.Sum(x => x.TaxTotal);
            }

            if (!cart.Payments.IsNullOrEmpty())
            {
                cart.PaymentTotal = cart.Payments.Sum(x => x.Total);
                cart.PaymentTotalWithTax = cart.Payments.Sum(x => x.TotalWithTax);
                cart.PaymentSubTotal = cart.Payments.Sum(x => x.Price);
                cart.PaymentSubTotalWithTax = cart.Payments.Sum(x => x.PriceWithTax);
                cart.PaymentDiscountTotal = cart.Payments.Sum(x => x.DiscountAmount);
                cart.PaymentDiscountTotalWithTax = cart.Payments.Sum(x => x.DiscountAmountWithTax);
                cart.DiscountTotal += cart.Payments.Sum(x => x.DiscountAmount);
                cart.DiscountTotalWithTax += cart.Payments.Sum(x => x.DiscountAmountWithTax);
                cart.TaxTotal += cart.Payments.Sum(x => x.TaxTotal);
            }
            cart.DiscountAmountWithTax = cart.DiscountAmount + cart.DiscountAmount * cart.TaxPercentRate;
            cart.FeeTotalWithTax = cart.Fee + cart.Fee * cart.TaxPercentRate;
            cart.DiscountTotal += cart.DiscountAmount;
            cart.DiscountTotalWithTax += cart.DiscountAmountWithTax;
            //Subtract from cart tax total self discount tax amount
            cart.TaxTotal -= cart.DiscountAmountWithTax - cart.DiscountAmount;
            cart.Total = cart.SubTotal + cart.ShippingSubTotal + cart.TaxTotal + cart.PaymentSubTotal + cart.FeeTotal - cart.DiscountTotal;
        }

        protected virtual void CalculatePaymentTotals(Model.Payment payment)
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

            lineItem.PlacedPrice = lineItem.ListPrice - lineItem.DiscountAmount;
            lineItem.ExtendedPrice = lineItem.PlacedPrice * lineItem.Quantity;
            lineItem.DiscountAmountWithTax = lineItem.DiscountAmount + lineItem.DiscountAmount * lineItem.TaxPercentRate;
            lineItem.DiscountTotal = lineItem.DiscountAmount * Math.Max(1, lineItem.Quantity);
            lineItem.FeeWithTax = lineItem.Fee + lineItem.Fee * lineItem.TaxPercentRate;
            lineItem.ListPriceWithTax = lineItem.ListPrice + lineItem.ListPrice * lineItem.TaxPercentRate;
            lineItem.SalePriceWithTax = lineItem.SalePrice + lineItem.SalePrice * lineItem.TaxPercentRate;
            lineItem.PlacedPriceWithTax = lineItem.PlacedPrice + lineItem.PlacedPrice * lineItem.TaxPercentRate;
            lineItem.ExtendedPriceWithTax = lineItem.PlacedPriceWithTax * lineItem.Quantity;
            lineItem.DiscountTotalWithTax = lineItem.DiscountAmountWithTax * Math.Max(1, lineItem.Quantity);
            lineItem.TaxTotal = lineItem.ExtendedPriceWithTax - lineItem.ExtendedPrice + lineItem.FeeWithTax - lineItem.Fee;
        }
    }
}
