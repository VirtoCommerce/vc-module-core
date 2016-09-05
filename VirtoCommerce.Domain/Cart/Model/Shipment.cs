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

        private decimal? _total;
        public virtual decimal Total
        {
            get
            {
                var retVal = _total;
                if(retVal == null)
                {
                    retVal = ShippingPrice - DiscountTotal;
                }
                return retVal.Value;
            }
            set
            {
                _total = value;
            }
        }

        private decimal? _totalWithTax;
        public virtual decimal TotalWithTax
        {
            get
            {
                var retVal = _totalWithTax;
                if (retVal == null)
                {
                    retVal = ShippingPriceWithTax - DiscountTotalWithTax;
                }
                return retVal.Value;
            }
            set
            {
                _totalWithTax = value;
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

        private decimal? _taxTotal;
        public virtual decimal TaxTotal
        {
            get
            {
                var retVal = _taxTotal;
                if(retVal == null)
                {
                    retVal = Math.Abs(TotalWithTax - Total);
                }
                return retVal.Value;
            }
            set
            {
                _taxTotal = value;
            }
        }

        private decimal? _itemSubtotal;
        /// <summary>
        /// Total of  shipment items
        /// </summary>
        public virtual decimal ItemSubtotal
        {
            get
            {
                var retVal = _itemSubtotal;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal = Items.Sum(i => i.LineItem.ExtendedPrice);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _itemSubtotal = value;
            }
        }

        private decimal? _itemSubtotalWithTax;
        public decimal ItemSubtotalWithTax
        {
            get
            {
                var retVal = _itemSubtotalWithTax;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal = Items.Sum(i => i.LineItem.ExtendedPriceWithTax);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _itemSubtotalWithTax = value;
            }
        }

        private decimal? _subtotal;
        public decimal Subtotal
        {
            get
            {
                var retVal = _subtotal;
                if (retVal == null)
                {
                    retVal = ShippingPrice - DiscountTotal; 
                }
                return retVal.Value;
            }
            set
            {
                _subtotal = value;
            }
        }

        private decimal? _subtotalWithTax;
        public decimal SubtotalWithTax
        {
            get
            {
                var retVal = _subtotalWithTax;
                if (retVal == null)
                {
                    retVal = ShippingPriceWithTax - DiscountTotalWithTax;
                }
                return retVal.Value;
            }
            set
            {
                _subtotalWithTax = value;
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
