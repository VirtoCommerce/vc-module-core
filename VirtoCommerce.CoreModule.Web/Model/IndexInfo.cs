using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Web.Model
{
    public class IndexInfo : Entity
    {
        public IndexInfo(string documentType)
        {
            Id = documentType;
            DocumentType = documentType;
        }

        public string DocumentType { get; }

        public long? IndexedDocumentsCount { get; set; }
        public long? UnindexedDocumentsCount { get; set; }

        public DateTime? LastIndexationDate { get; set; }
    }
}
