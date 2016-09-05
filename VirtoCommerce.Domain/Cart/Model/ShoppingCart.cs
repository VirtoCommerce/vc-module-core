using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Cart.Model
{
	public class ShoppingCart : AuditableEntity, IHaveTaxDetalization, IHasDynamicProperties
    {
		public string Name { get; set; }
		public string StoreId { get; set; }
		public string ChannelId { get; set; }
		public bool IsAnonymous { get; set; }
		public string CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string OrganizationId { get; set; }
		public string Currency { get; set; }
	
		public string LanguageCode { get; set; }
		public bool? TaxIncluded { get; set; }
		public bool? IsRecuring { get; set; }
		public string Comment { get; set; }

		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

        /// <summary>
        /// Represent any line item validation type (noPriceValidate, noQuantityValidate etc) this value can be used in storefront 
        /// to select appropriate validation strategy
        /// </summary>
        public string ValidationType { get; set; }

        public decimal? VolumetricWeight { get; set; }

        private decimal? _total;
        public virtual decimal Total
        {
            get
            {
                var retVal = _total;
                if (retVal == null)
                {
                    retVal = SubTotal + TaxTotal + ShippingTotal - DiscountTotal;
                }
                return retVal.Value;
            }
            set
            {
                _total = value;
            }
        }

        private decimal? _subtotal;
        public virtual decimal SubTotal
        {
            get
            {
                var retVal = _subtotal;
                if(retVal == null)
                {
                    retVal = 0;
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal = Items.Sum(i => i.ListPrice * i.Quantity);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _subtotal = value;
            }
        }

        private decimal? _subtotalWithTax;
        public virtual decimal SubTotalWithTax
        {
            get
            {
                var retVal = _subtotalWithTax;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal = Items.Sum(i => i.ListPriceWithTax * i.Quantity);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _subtotalWithTax = value;
            }
        }

        private decimal? _shippingTotal;
        public virtual decimal ShippingTotal
        {
            get
            {
                var retVal = _shippingTotal;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Shipments.IsNullOrEmpty())
                    {
                        retVal = Shipments.Sum(s => s.ShippingPrice);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _shippingTotal = value;
            }
        }
        private decimal? _shippingTotalWithTax;
        public virtual decimal ShippingTotalWithTax
        {
            get
            {
                var retVal = _shippingTotalWithTax;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Shipments.IsNullOrEmpty())
                    {
                        retVal = Shipments.Sum(s => s.ShippingPriceWithTax);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _shippingTotalWithTax = value;
            }
        }

        public virtual decimal HandlingTotal { get; set; }
        public virtual decimal HandlingTotalWithTax { get; set; }

        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal DiscountAmountWithTax { get; set; }

        private decimal? _discountTotal;
		public virtual decimal DiscountTotal
        {
            get
            {
                var retVal = _discountTotal;
                if(retVal == null)
                {
                    retVal = DiscountAmount;                  
                    if(!Items.IsNullOrEmpty())
                    {
                        retVal += Items.Sum(i => i.DiscountTotal);
                    }
                    if (!Shipments.IsNullOrEmpty())
                    {
                        retVal += Shipments.Sum(s => s.DiscountTotal);
                    }
                }
                return retVal.Value;             
            }
            set
            {
                _discountTotal = value;
            }
        }

        private decimal? _discountTotalWithTax;
        public virtual decimal DiscountTotalWithTax
        {
            get
            {
                var retVal = _discountTotalWithTax;
                if (retVal == null)
                {
                    retVal = DiscountAmountWithTax;               
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal += Items.Sum(i => i.DiscountTotalWithTax);
                    }
                    if (!Shipments.IsNullOrEmpty())
                    {
                        retVal += Shipments.Sum(s => s.DiscountTotalWithTax);
                    }
                }
                return retVal.Value;
            }

            set
            {
                _discountTotalWithTax = value;
            }
        }

        private decimal? _taxTotal;
        public virtual decimal TaxTotal
        {
            get
            {
                var retVal = _taxTotal;
                if (retVal == null)
                {
                    retVal = 0;
                    if (!Items.IsNullOrEmpty())
                    {
                        retVal += Items.Sum(i => i.TaxTotal);
                    }
                    if (!Shipments.IsNullOrEmpty())
                    {
                        retVal += Shipments.Sum(s => s.TaxTotal);
                    }
                }
                return retVal.Value;
            }
            set
            {
                _taxTotal = value;
            }
        }

        public ICollection<Address> Addresses { get; set; }
		public ICollection<LineItem> Items { get; set; }
		public ICollection<Payment> Payments { get; set; }
		public ICollection<Shipment> Shipments { get; set; }
		public ICollection<Discount> Discounts { get; set; }
		public Coupon Coupon { get; set; }

		#region IHaveTaxDetalization Members
		public ICollection<TaxDetail> TaxDetails { get; set; }
        #endregion

        #region IHasDynamicProperties Members
        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }

        #endregion
    }
}
