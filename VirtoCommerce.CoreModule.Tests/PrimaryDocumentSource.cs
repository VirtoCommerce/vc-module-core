using System;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public class PrimaryDocumentSource : DocumentSourceBase
    {
        protected override IndexDocument[] Documents { get; } =
        {
            new IndexDocument("2"),
            new IndexDocument("3"),
            new IndexDocument(""),
        };

        protected override IndexDocumentChange[] Changes { get; } =
        {
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 1), DocumentId = "1", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 2), DocumentId = "2", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 3), DocumentId = "3", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 3), DocumentId = "", ChangeType = IndexDocumentChangeType.Modified },
            new IndexDocumentChange { ChangeDate = new DateTime(1, 1, 4), DocumentId = "1", ChangeType = IndexDocumentChangeType.Deleted },
        };
    }
}
