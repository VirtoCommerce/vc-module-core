using System.Collections.Generic;
using Newtonsoft.Json;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Tax.Model
{
    public class TaxRate : ValueObject
    {
        public TaxRate()
        {
            TaxDetails = new List<TaxDetail>();
        }

        public decimal Rate { get; set; }
        public string Currency { get; set; }

        public TaxLine Line { get; set; }
        [JsonIgnore]
        public TaxProvider TaxProvider { get; set; }
        public string TaxProviderCode { get; set; }
        public ICollection<TaxDetail> TaxDetails { get; set; }
    }
}
