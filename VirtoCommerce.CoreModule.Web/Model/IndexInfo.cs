using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.CoreModule.Web.Model
{
    public class IndexInfo : Entity
    {
        public IndexInfo(string docType)
        {
            Id = docType;
            DocumentType = docType;
        }
        public string DocumentType { get; private set; }
        public long UnindexedDocsTotal { get; set; }
        public long? IndexedDocsTotal { get; set; }

        public DateTime? LastIndexationDate { get; set; }
    }
}