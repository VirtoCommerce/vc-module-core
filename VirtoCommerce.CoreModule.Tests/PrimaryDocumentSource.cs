using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public class PrimaryDocumentSource : DocumentSourceBase
    {
        public override IList<IndexDocument> Documents { get; } = new[]
        {
            CreateDocument("bad1", "primary"),
            CreateDocument("good2", "primary"),
            CreateDocument("good3", "primary"),
        };

        public override IList<IndexDocumentChange> Changes { get; } = new[]
        {
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 1), DocumentId = "bad1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 2), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 3), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Deleted },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 4), DocumentId = "good2", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 5), DocumentId = "good3", ChangeType = IndexDocumentChangeType.Modified },
        };
    }
}
