using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class ResultDocumentSet : IDocumentSet
    {
        public string Name { get; set; }

        public int TotalCount
        {
            get;set;
        }

        public object[] Properties
        {
            get;set;
        }

        public IDocument[] Documents
        {
            get;
            set;
        }
    }
}
