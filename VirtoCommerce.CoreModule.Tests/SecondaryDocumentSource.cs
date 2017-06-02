using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public class SecondaryDocumentSource : DocumentSourceBase
    {
        public override IList<IndexDocument> Documents { get; } = new[]
        {
            CreateDocument("bad1", "secondary"),
            CreateDocument("good2", "secondary"),
            CreateDocument("good3", "secondary"),
        };

        public override IList<IndexDocumentChange> Changes { get; } = new[]
        {
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 2), DocumentId = "bad1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 3), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 4), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 5), DocumentId = "good2", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 6), DocumentId = "good2", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 7), DocumentId = "good3", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 8), DocumentId = "good3", ChangeType = IndexDocumentChangeType.Modified },
        };
    }
}
