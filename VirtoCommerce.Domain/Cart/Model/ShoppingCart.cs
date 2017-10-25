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
	public class ShoppingCart : AuditableEntity, IHaveTaxDetalization, IHasDynamicProperties, ITaxable, IHasDiscounts
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

        public string Status { get; set; }

		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

        /// <summary>
        /// Represent any line item validation type (noPriceValidate, noQuantityValidate etc) this value can be used in storefront 
        /// to select appropriate validation strategy
        /// </summary>
        public string ValidationType { get; set; }

        public decimal? VolumetricWeight { get; set; }
        //Grand  cart total
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
                    retVal = Items.Sum(i => i.ListPrice * i.Quantity);
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
                    retVal = Items.Sum(i => i.ListPriceWithTax * i.Quantity);
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

      
        public virtual decimal PaymentTotal
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.Total);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.TotalWithTax);
                }
                return retVal;
            }
        }
        public virtual decimal PaymentSubTotal
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.Price);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentSubTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.PriceWithTax);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentDiscountTotal
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.DiscountAmount);
                }
                return retVal;
            }
        }

        public virtual decimal PaymentDiscountTotalWithTax
        {
            get
            {
                var retVal = 0m;
                if (!Payments.IsNullOrEmpty())
                {
                    retVal = Payments.Sum(x => x.DiscountAmountWithTax);
                }
                return retVal;
            }
        }
        public virtual decimal HandlingTotal { get; set; }
        public virtual decimal HandlingTotalWithTax { get; set; }

        /// <summary>
        /// Cart subtotal discount
        /// When a discount is applied to the cart subtotal, the tax calculation has already been applied, and is reflected in the tax subtotal.
        /// Therefore, a discount applying to the cart subtotal will occur after tax.
        /// For instance, if the cart subtotal is $100, and $15 is the tax subtotal, a cart - wide discount of 10 % will yield a total of $105($100 subtotal – $10 discount + $15 tax on the original $100).
        /// </summary>
        public virtual decimal DiscountAmount { get; set; }

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
                if (!Payments.IsNullOrEmpty())
                {
                    retVal += Payments.Sum(s => s.DiscountAmount);
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
                if (!Payments.IsNullOrEmpty())
                {
                    retVal += Payments.Sum(s => s.DiscountAmountWithTax);
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

        public ICollection<Address> Addresses { get; set; }
		public ICollection<LineItem> Items { get; set; }
		public ICollection<Payment> Payments { get; set; }
		public ICollection<Shipment> Shipments { get; set; }
        /// <summary>
        /// Entered multiple coupons
        /// </summary>
        private ICollection<string> _coupons;
        public ICollection<string> Coupons
        {
            get
            {
                if (_coupons == null && !string.IsNullOrEmpty(Coupon))
                {
                    _coupons = new List<string>() { Coupon };
                }
                return _coupons;
            }
            set
            {
                _coupons = value;
            }
        }
        public string Coupon { get; set; }

        #region IHasDiscounts
        public ICollection<Discount> Discounts { get; set; } 
        #endregion

        #region ITaxable Members

        /// <summary>
        /// Tax category or type
        /// </summary>
        public string TaxType { get; set; }

        public virtual decimal TaxTotal
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
                if (!Payments.IsNullOrEmpty())
                {
                    retVal += Payments.Sum(s => s.TaxTotal);
                }
                return retVal;
            }
        }

        public  decimal TaxPercentRate { get; set; }

        #endregion
        #region IHaveTaxDetalization Members
        public ICollection<TaxDetail> TaxDetails { get; set; }
        #endregion

        #region IHasDynamicProperties Members
        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }

        #endregion
    }
}
