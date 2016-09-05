using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Order.Model
{
    public class LineItem : AuditableEntity, IHaveTaxDetalization, ISupportCancellation, IHaveDimension, IHasDynamicProperties
    {
        /// <summary>
        /// Price id
        /// </summary>
        public string PriceId { get; set; }

        public string Currency { get; set; }
     
        /// <summary>
        ///  unit price without discount and tax
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

        /// <summary>
        /// Resulting price with discount for one unit
        /// </summary>
        public virtual decimal PlacedPrice
        {
            get
            {
                return Price - DiscountAmount;
            }
        }

        public virtual decimal PlacedPriceWithTax
        {
            get
            {
                return PriceWithTax - DiscountAmountWithTax;
            }
        }


        /// <summary>
        /// Gets the value of line item subtotal price (actual price * line item quantity)
        /// </summary>        
        public virtual decimal ExtendedPrice
        {
            get
            {
                return PlacedPrice * Quantity;
            }
        }

        public virtual decimal ExtendedPriceWithTax
        {
            get
            {
                return PlacedPriceWithTax * Quantity;
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


        private decimal? _discountTotal;
        public virtual decimal DiscountTotal
        {
            get
            {
                var retVal = _discountTotal;
                if (retVal == null)
                {
                    retVal = DiscountAmount * Quantity;
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
                    retVal = DiscountAmountWithTax * Quantity;
                }
                return retVal.Value;
            }
            set
            {
                _discountTotalWithTax = value;
            }
        }


        private decimal? _tax;
        public virtual decimal Tax
        {
            get
            {
                var retVal = _tax;
                if (retVal == null)
                {
                    retVal = Math.Abs(ExtendedPriceWithTax - ExtendedPrice);
                }
                return retVal.Value;
            }
            set
            {
                _tax = value;
            }
        }

        /// <summary>
        /// Tax category or type
        /// </summary>
        public string TaxType { get; set; }

        /// <summary>
        /// Reserve quantity
        /// </summary>
        public int ReserveQuantity { get; set; }
        public int Quantity { get; set; }

        public string ProductId { get; set; }
        public CatalogProduct Product { get; set; }
        public string Sku { get; set; }
        public string ProductType { get; set; }
        public string CatalogId { get; set; }
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string ImageUrl { get; set; }

        public bool? IsGift { get; set; }
        public string ShippingMethodCode { get; set; }
        public string FulfillmentLocationCode { get; set; }

        #region IHaveDimension Members
        public string WeightUnit { get; set; }
        public decimal? Weight { get; set; }

        public string MeasureUnit { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        #endregion

        #region ISupportCancelation Members

        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        public string CancelReason { get; set; }

        #endregion

        #region IHasDynamicProperties Members
        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }
        #endregion

        public Discount Discount { get; set; }
        public ICollection<TaxDetail> TaxDetails { get; set; }
    }
}
