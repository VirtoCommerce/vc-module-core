using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Model
{
	public class Payment : AuditableEntity, IHaveTaxDetalization, ITaxable, IHasDiscounts
    {
		public string OuterId { get; set; }
		public string Currency { get; set; }
		public string PaymentGatewayCode { get; set; }
		public decimal Amount { get; set; }

		public Address BillingAddress { get; set; }


        public virtual decimal Price { get; set; }
        public virtual decimal PriceWithTax
        {
            get
            {
                return Price + Price * TaxPercentRate;
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

        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return DiscountAmount + DiscountAmount * TaxPercentRate;
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
                return TotalWithTax - Total;
            }
        }

        public decimal TaxPercentRate { get; set; }

        #endregion



        #region IHasDiscounts
        public ICollection<Discount> Discounts { get; set; }
        #endregion

        #region ITaxDetailSupport Members

        public ICollection<TaxDetail> TaxDetails { get; set; }

        #endregion
    }
}
