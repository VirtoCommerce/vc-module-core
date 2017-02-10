using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.DynamicContent.Search
{
    public class DynamicContentPublicationSearchCriteria : DynamicContentSearchCriteriaBase
    {
        public string OnlyActive { get; set; }
        public string Store { get; set; }
    }
}
