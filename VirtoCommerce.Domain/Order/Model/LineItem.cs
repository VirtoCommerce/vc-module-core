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
    public class LineItem : AuditableEntity, IHaveTaxDetalization, ISupportCancellation, IHaveDimension, IHasDynamicProperties, ITaxable, IHasDiscounts
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

        public virtual decimal PriceWithTax
        {
            get
            {
                return Price + Price * TaxPercentRate;
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
                return PlacedPrice + PlacedPrice * TaxPercentRate;
            }
        }

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

        /// <summary>
        /// Gets the value of the single qty line item discount amount
        /// </summary>
        public virtual decimal DiscountAmount { get; set; }

        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return DiscountAmount + DiscountAmount * TaxPercentRate;
            }
        }

        public decimal DiscountTotal
        {
            get
            {
                return DiscountAmount * Math.Max(1, Quantity);
            }
        }

        public decimal DiscountTotalWithTax
        {
            get
            {
                return DiscountAmountWithTax * Math.Max(1, Quantity);
            }
        }

        //Any extra Fee 
        public virtual decimal Fee { get; set; }

        public virtual decimal FeeWithTax
        {
            get
            {
                return Fee + Fee * TaxPercentRate;
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
                return ExtendedPriceWithTax - ExtendedPrice + FeeWithTax - Fee;
            }
        }

        public decimal TaxPercentRate { get; set; }

        #endregion
        
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


        #region IHasDiscounts
        public ICollection<Discount> Discounts { get; set; }
        #endregion

        #region IHaveTaxDetalization Members
        public ICollection<TaxDetail> TaxDetails { get; set; }
        #endregion
    }
}
