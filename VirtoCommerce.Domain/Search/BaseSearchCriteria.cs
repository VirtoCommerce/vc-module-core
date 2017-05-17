using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class BaseSearchCriteria
    {
        public BaseSearchCriteria(string documentType)
        {
            DocumentType = documentType;
        }

        public virtual string DocumentType { get; }
        public virtual IList<string> Ids { get; set; }
        public virtual IList<SortingField> Sorting { get; set; }
        public virtual int Skip { get; set; }
        public virtual int Take { get; set; } = 10;
    }
}
