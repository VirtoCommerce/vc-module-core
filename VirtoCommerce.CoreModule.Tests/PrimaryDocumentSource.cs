using System;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public class PrimaryDocumentSource : DocumentSourceBase
    {
        protected override IndexDocument[] Documents { get; } =
        {
            new IndexDocument("bad1"),
            new IndexDocument("good2"),
            new IndexDocument("good3"),
        };

        protected override IndexDocumentChange[] Changes { get; } =
        {
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 1), DocumentId = "bad1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 2), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 3), DocumentId = "good1", ChangeType = IndexDocumentChangeType.Deleted },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 4), DocumentId = "good2", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 5), DocumentId = "good3", ChangeType = IndexDocumentChangeType.Modified },
        };
    }
}
