using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Tax.Model
{
    public class TaxEvaluationContext : Entity, IEvaluationContext
    {
        public Store.Model.Store Store { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        
        public Customer.Model.Contact Customer { get; set; }
        public Customer.Model.Organization Organization { get; set; }
        public Address Address { get; set; }
        public string Currency { get; set; }

        public ICollection<TaxLine> Lines { get; set; } = new List<TaxLine>();
    }
}