using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.DynamicContent.Search
{
    public class DynamicContentSearchCriteriaBase : SearchCriteriaBase
    {
        public string FolderId { get; set; }
        public string Keyword { get; set; }
    }
}
