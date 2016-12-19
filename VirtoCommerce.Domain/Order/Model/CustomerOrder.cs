using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Domain.Order.Model
{
    public class CustomerOrder : OrderOperation, IHaveTaxDetalization, ISupportSecurityScopes, ITaxable, ILanguageSupport
	{
  		public string CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string ChannelId { get; set; }
		public string StoreId { get; set; }
		public string StoreName { get; set; }
		public string OrganizationId { get; set; }
		public string OrganizationName { get; set; }
		public string EmployeeId { get; set; }
		public string EmployeeName { get; set; }

        /// <summary>
        /// Flag determines that the order is the prototype
        /// </summary>
        public bool IsPrototype { get; set; }
        /// <summary>
        /// Number for subscription  associated with this order
        /// </summary>
        public string SubscriptionNumber { get; set; }
        /// <summary>
        /// Identifier for subscription  associated with this order
        /// </summary>
        public string SubscriptionId { get; set; }
 
		public ICollection<Address> Addresses { get; set; }
		public ICollection<PaymentIn> InPayments { get; set; }

		public ICollection<LineItem> Items { get; set; }
		public ICollection<Shipment> Shipments { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        /// <summary>
        /// When a discount is applied to the order, the tax calculation has already been applied, and is reflected in the tax.
        /// Therefore, a discount applying to the order  will occur after tax. 
        /// For instance, if the cart subtotal is $100, and $15 is the tax subtotal, a cart-wide discount of 10% will yield a total of $105 ($100 subtotal – $10 discount + $15 tax on the original $100).
        /// </summary>
		public decimal DiscountAmount { get; set; }
      
        #region ITaxDetailSupport Members

        public ICollection<TaxDetail> TaxDetails { get; set; }

        #endregion

        #region ISupportSecurityScopes Members
        public IEnumerable<string> Scopes { get; set; }
        #endregion


        /// <summary>
        /// Grand order total
        /// </summary>
        public virtual decimal Total
        {
            get
            {
                return SubTotal + ShippingSubTotal + TaxTotal + PaymentSubTotal + FeeTotal - DiscountTotal;
            }
        }


        public virtual decimal SubTotal
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.Price * i.Quantity);
                }
                return retVal;
            }
        }

        public virtual decimal SubTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.PriceWithTax * i.Quantity);
                }
                return retVal;
            }
        }

        public virtual decimal SubTotalDiscount
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.DiscountTotal);
                }
                return retVal;
            }
        }

        public virtual decimal SubTotalDiscountWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.DiscountTotalWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal SubTotalTaxTotal
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.TaxTotal);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingTotal
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.Total);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.TotalWithTax);
                }
                return retVal;
            }
        }
      
        public virtual decimal ShippingSubTotal
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.Price);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingSubTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.PriceWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingDiscountTotal
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.DiscountAmount);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingDiscountTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.DiscountAmountWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingTaxTotal
        {
            get
            {
                var retVal = 0m;
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal = Shipments.Sum(s => s.TaxTotal);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentTotal
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.Total);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.TotalWithTax);
                }
                return retVal;
            }
        }


        public virtual decimal PaymentSubTotal
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.Price);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentSubTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.PriceWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentDiscountTotal
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.DiscountAmount);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentDiscountTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(x => x.DiscountAmountWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentTaxTotal
        {
            get
            {
                var retVal = 0m;
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal = InPayments.Sum(s => s.TaxTotal);
                }
                return retVal;
            }
        }

        public virtual decimal DiscountTotal
        {
            get
            {
                var retVal = DiscountAmount;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.DiscountTotal);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.DiscountAmount);
                }
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal += InPayments.Sum(x => x.DiscountAmount);
                }
                return retVal;
            }
        }

        public virtual decimal DiscountTotalWithTax
        {
            get
            {
                var retVal = DiscountAmount;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.DiscountTotalWithTax);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.DiscountAmountWithTax);
                }
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal += InPayments.Sum(x => x.DiscountAmountWithTax);
                }
                return retVal;
            }         
        }


        //Any extra Fee 
        public decimal Fee { get; set; }

        public virtual decimal FeeWithTax
        {
            get
            {
                return Fee + Fee * TaxPercentRate;
            }
        }

        public virtual decimal FeeTotal
        {
            get
            {
                var retVal = Fee;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.Fee);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.Fee);
                }
                return retVal;
            }
        }

        public virtual decimal FeeTotalWithTax
        {
            get
            {
                var retVal = FeeWithTax;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.FeeWithTax);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.FeeWithTax);
                }
                return retVal;
            }
        }
        #region ITaxable Members

        /// <summary>
        /// Tax category or type
        /// </summary>
        public string TaxType { get; set; }

        public decimal TaxTotal
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.TaxTotal);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.TaxTotal);
                }
                if (!InPayments.IsNullOrEmpty())
                {
                    retVal += InPayments.Sum(x => x.TaxTotal);
                }
                return retVal;
            }        
        }

        public decimal TaxPercentRate { get; set; }

        #endregion

        #region ILanguageSupport Members

        public string LanguageCode { get; set; }

        #endregion

    }
}
