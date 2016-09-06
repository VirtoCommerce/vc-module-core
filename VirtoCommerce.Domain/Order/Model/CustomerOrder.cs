using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Domain.Order.Model
{
    public class CustomerOrder : OrderOperation, IHaveTaxDetalization, ISupportSecurityScopes
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

		public ICollection<Address> Addresses { get; set; }
		public ICollection<PaymentIn> InPayments { get; set; }

		public ICollection<LineItem> Items { get; set; }
		public ICollection<Shipment> Shipments { get; set; }

		public Discount Discount { get; set; }

		public decimal DiscountAmount { get; set; }
        public decimal DiscountAmountWithTax { get; set; }

        #region ITaxDetailSupport Members

        public ICollection<TaxDetail> TaxDetails { get; set; }

        #endregion

        #region ISupportSecurityScopes Members
        public IEnumerable<string> Scopes { get; set; }
        #endregion

     
        public virtual decimal Total
        {
            get
            {
                return SubTotal + TaxTotal + ShippingTotal - DiscountTotal;
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

        public virtual decimal ShippingTotal
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

        public virtual decimal ShippingTotalWithTax
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

        public virtual decimal DiscountTotal
        {
            get
            {
                var retVal = DiscountAmount;
                if (Items != null)
                {
                    retVal += Items.Sum(i => i.DiscountTotal);
                }
                if (Shipments != null)
                {
                    retVal += Shipments.Sum(s => s.DiscountAmount);
                }
                return retVal;
            }
        }

        public virtual decimal DiscountTotalWithTax
        {
            get
            {
                var retVal = DiscountAmountWithTax;
                if (Items != null)
                {
                    retVal += Items.Sum(i => i.DiscountTotalWithTax);
                }
                if (Shipments != null)
                {
                    retVal += Shipments.Sum(s => s.DiscountAmountWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal TaxTotal
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal += Items.Sum(i => i.Tax);
                }
                if (!Shipments.IsNullOrEmpty())
                {
                    retVal += Shipments.Sum(s => s.TaxTotal);
                }
                return retVal;
            }
        }

    }
}
