using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class Document
    {
        public string Id { get; set; }
        public IList<DocumentField> Fields { get; set; }
    }
}
