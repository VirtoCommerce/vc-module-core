using System;
using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class IndexDocument
    {
        public string DocumentType { get; set; }
        public string Id { get; set; }
        public IList<IndexDocumentField> Fields { get; set; }
        public bool DoNotIndex { get; set; }

        public void Merge(IndexDocument doc)
        {
            throw new NotImplementedException();
        }
    }
}
