using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Shipping.Model;

namespace VirtoCommerce.Domain.Order.Model
{
	public class Shipment : OrderOperation, IHaveTaxDetalization, ISupportCancellation
	{
		public string OrganizationId { get; set; }
		public string OrganizationName { get; set; }

		public string FulfillmentCenterId { get; set; }
		public string FulfillmentCenterName { get; set; }

		public string EmployeeId { get; set; }
		public string EmployeeName { get; set; }

        /// <summary>
        /// Current shipment method code 
        /// </summary>
		public string ShipmentMethodCode { get; set; }

        /// <summary>
        /// Current shipment option code 
        /// </summary>
        public string ShipmentMethodOption { get; set; }

        public Discount Discount { get; set; }
        /// <summary>
        ///  Shipment method contains additional shipment method information
        /// </summary>
        public ShippingMethod ShippingMethod { get; set; }

        public string CustomerOrderId { get; set; }
		public CustomerOrder CustomerOrder { get; set; }

		public ICollection<ShipmentItem> Items { get; set; } 

		public ICollection<ShipmentPackage> Packages { get; set; }

		public ICollection<PaymentIn> InPayments { get; set; }

		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

		public string MeasureUnit { get; set; }
		public decimal? Height { get; set; }
		public decimal? Length { get; set; }
		public decimal? Width { get; set; }

		public string TaxType { get; set; }

		public Address DeliveryAddress { get; set; }
    
        /// <summary>
        ///  shipping  price without discount and tax
        /// </summary>
        public decimal Price { get; set; }

        private decimal? _priceWithTax;
        public virtual decimal PriceWithTax
        {
            get
            {
                return _priceWithTax ?? Price;
            }
            set
            {
                _priceWithTax = value;
            }
        }

        public virtual decimal Total
        {
            get
            {
                return Price - DiscountAmount;
            }
        }

        public virtual decimal TotalWithTax
        {
            get
            {
                return PriceWithTax - DiscountAmountWithTax;
            }
        }

        public virtual decimal ItemsSubtotal
        {
            get
            {
                decimal retVal = 0;
                if(Items != null)
                {
                    retVal = Items.Sum(i => i.LineItem.ExtendedPrice);
                }
                return retVal;
            }
        }

        public virtual decimal ItemsSubtotalWithTax
        {
            get
            {
                decimal retVal = 0;
                if (Items != null)
                {
                    retVal = Items.Sum(i => i.LineItem.ExtendedPriceWithTax);
                }
                return retVal;
            }
        }

     
        public virtual decimal DiscountAmount { get; set; }

        private decimal? _dicountAmountWithTax;
        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return _dicountAmountWithTax ?? DiscountAmount;             
            }
            set
            {
                _dicountAmountWithTax = value;
            }
        }


        public virtual decimal TaxTotal
        {
            get
            {
                return Math.Abs(TotalWithTax - Total);
            }
        }


        #region ITaxDetailSupport Members

        public ICollection<TaxDetail> TaxDetails { get; set; }

		#endregion
	}
}
