using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
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
                return SubTotal + TaxTotal + ShippingPrice - DiscountTotal;
            }
        }

        public virtual decimal TotalWithTax
        {
            get { return Total + TaxTotal; }
        }

        public virtual decimal SubTotal
        {
            get
            {
                decimal retVal = 0;
                if (Items != null)
                {
                    retVal = Items.Sum(i => i.BasePrice * i.Quantity);
                }
                return retVal;
            }
        }
        public virtual decimal SubTotalWithTax
        {
            get
            {
                decimal retVal = 0;
                if (Items != null)
                {
                    retVal = Items.Sum(i => i.BasePriceWithTax * i.Quantity);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingTotal
        {
            get
            {
                decimal retVal = 0;
                if (Shipments != null)
                {
                    retVal = Shipments.Sum(x => x.Total);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingTotalWithTax
        {
            get
            {
                decimal retVal = 0;
                if (Shipments != null)
                {
                    retVal = Shipments.Sum(x => x.TotalWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingPrice
        {
            get
            {
                decimal retVal = 0;
                if (Shipments != null)
                {
                    retVal = Shipments.Sum(s => s.Price);
                }
                return retVal;
            }
        }

        public virtual decimal ShippingPriceWithTax
        {
            get
            {
                decimal retVal = 0;
                if (Shipments != null)
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
                decimal retVal = DiscountAmount;
                if (Items != null)
                {
                    retVal  += Items.Sum(i => i.DiscountTotal);
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
                decimal retVal = DiscountAmountWithTax;
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
            get { return Tax; }
            set { Tax = value; }
        }
    }
}
