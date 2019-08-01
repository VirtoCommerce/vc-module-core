using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Commerce.Model
{
    public class TaxDetail : ValueObject
    {
        /// <summary>
        /// The tax present rate
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// The tax amount
        /// </summary>
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}
