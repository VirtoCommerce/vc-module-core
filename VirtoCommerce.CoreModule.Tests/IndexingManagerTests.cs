using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Data.Indexing;
using VirtoCommerce.Domain.Search;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    [Trait("Category", "CI")]
    public class IndexingManagerTests
    {
        private const string _documentType = "item";

        [Fact]
        public async Task CanRebuildIndexWithPrimarySourceOnly()
        {
            var manager = GetIndexingManager();
            var progress = new List<IndexingProgress>();
            var cancellationTokenSource = new CancellationTokenSource();

            var options = new IndexingOptions
            {
                DocumentType = _documentType,
                RebuildIndex = true,
                BatchSize = 1,
            };

            await manager.IndexAsync(options, p => progress.Add(p), cancellationTokenSource.Token);

            Assert.Equal(9, progress.Count);

            var errors = progress.Where(p => p.Errors != null).SelectMany(p => p.Errors).ToList();
            Assert.Equal(1, errors.Count);
            Assert.Equal("ID: , Error: Document ID is empty", errors[0]);
        }


        private static IIndexingManager GetIndexingManager()
        {
            return new IndexingManager(GetSearchProvider(), new[] { GetIndexDocumentConfiguration() });
        }

        private static ISearchProvider GetSearchProvider()
        {
            return new SearchProvider();
        }

        private static IndexDocumentConfiguration GetIndexDocumentConfiguration()
        {
            var primaryDocumentSource = new PrimaryDocumentSource();

            return new IndexDocumentConfiguration
            {
                DocumentType = _documentType,
                DocumentSource = new IndexDocumentSource
                {
                    ChangesProvider = primaryDocumentSource,
                    DocumentBuilder = primaryDocumentSource,
                },
            };
        }
    }
}
