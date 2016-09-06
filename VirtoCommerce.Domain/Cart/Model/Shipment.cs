using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Model
{
	public class Shipment : Entity, IHaveTaxDetalization
	{
		public string ShipmentMethodCode { get; set; }
        public string ShipmentMethodOption { get; set; }
        public string  WarehouseLocation { get; set; }

		public string Currency { get; set; }
		public decimal? VolumetricWeight { get; set; }

		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

		public string MeasureUnit { get; set; }
		public decimal? Height { get; set; }
		public decimal? Length { get; set; }
		public decimal? Width { get; set; }

		public string TaxType { get; set; }

		public virtual decimal ShippingPrice { get; set; }

        private decimal? _shippingPriceWithTax;
        public virtual decimal ShippingPriceWithTax
        {
            get
            {
                return _shippingPriceWithTax ?? ShippingPrice;
            }
            set
            {
                _shippingPriceWithTax = value;
            }
        }

        public virtual decimal Total
        {
            get
            {
                return ShippingPrice - DiscountTotal;
            }
        }

        public virtual decimal TotalWithTax
        {
            get
            {
                return ShippingPriceWithTax - DiscountTotalWithTax;
            }
        }

        public virtual decimal DiscountTotal { get; set; }
        private decimal? _dicountTotalWithTax;
        public virtual decimal DiscountTotalWithTax
        {
            get
            {
                return _dicountTotalWithTax ?? DiscountTotal;             
            }
            set
            {
                _dicountTotalWithTax = value;
            }
        }

        public virtual decimal TaxTotal
        {
            get
            {
                return Math.Abs(TotalWithTax - Total);
            }
        }

        /// <summary>
        /// Total of  shipment items
        /// </summary>
        public virtual decimal ItemSubtotal
        {
            get
            {

                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.LineItem.ExtendedPrice);
                }
                return retVal;

            }
        }

        public decimal ItemSubtotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Items.IsNullOrEmpty())
                {
                    retVal = Items.Sum(i => i.LineItem.ExtendedPriceWithTax);
                }
                return retVal;
            }       
        }

        public decimal Subtotal
        {
            get
            {
                return ShippingPrice - DiscountTotal;
            }
        }

        public decimal SubtotalWithTax
        {
            get
            {
                return ShippingPriceWithTax - DiscountTotalWithTax;
            }
        }

        public Address DeliveryAddress { get; set; }

		public ICollection<Discount> Discounts { get; set; }
		public ICollection<ShipmentItem> Items { get; set; }

		#region IHaveTaxDetalization Members
		public ICollection<TaxDetail> TaxDetails { get; set; }
		#endregion
		
	}
}
