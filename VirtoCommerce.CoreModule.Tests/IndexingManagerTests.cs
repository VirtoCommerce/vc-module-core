using System;
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
            Assert.Equal("Deleting index", progress[0].Description);
            Assert.Equal("Calculating documents count", progress[1].Description);
            Assert.Equal("Processing", progress[2].Description);
            Assert.Equal("Processed", progress[3].Description);
            Assert.Equal("Processing", progress[4].Description);
            Assert.Equal("Processed", progress[5].Description);
            Assert.Equal("Processing", progress[6].Description);
            Assert.Equal("Processed", progress[7].Description);
            Assert.Equal("Completed", progress[8].Description);

            var errors = progress.Where(p => p.Errors != null).SelectMany(p => p.Errors).ToList();
            Assert.Equal(1, errors.Count);
            Assert.Equal("ID: bad1, Error: Search provider error", errors[0]);


            // Do the same with batch size = 3
            progress.Clear();
            options.BatchSize = 3;

            await manager.IndexAsync(options, p => progress.Add(p), cancellationTokenSource.Token);

            Assert.Equal(5, progress.Count);
            Assert.Equal("Deleting index", progress[0].Description);
            Assert.Equal("Calculating documents count", progress[1].Description);
            Assert.Equal("Processing", progress[2].Description);
            Assert.Equal("Processed", progress[3].Description);
            Assert.Equal("Completed", progress[4].Description);

            errors = progress.Where(p => p.Errors != null).SelectMany(p => p.Errors).ToList();
            Assert.Equal(1, errors.Count);
            Assert.Equal("ID: bad1, Error: Search provider error", errors[0]);
        }

        [Fact]
        public async Task CanUpdateIndexWithPrimarySourceOnly()
        {
            var manager = GetIndexingManager();
            var progress = new List<IndexingProgress>();
            var cancellationTokenSource = new CancellationTokenSource();

            var options = new IndexingOptions
            {
                DocumentType = _documentType,
                StartDate = new DateTime(1, 1, 1),
                EndDate = new DateTime(1, 1, 9),
                BatchSize = 1,
            };

            await manager.IndexAsync(options, p => progress.Add(p), cancellationTokenSource.Token);

            Assert.Equal(12, progress.Count);
            Assert.Equal("Calculating documents count", progress[0].Description);
            Assert.Equal("Processing", progress[1].Description);
            Assert.Equal("Processed", progress[2].Description);
            Assert.Equal("Processing", progress[3].Description);
            Assert.Equal("Processed", progress[4].Description);
            Assert.Equal("Processing", progress[5].Description);
            Assert.Equal("Processed", progress[6].Description);
            Assert.Equal("Processing", progress[7].Description);
            Assert.Equal("Processed", progress[8].Description);
            Assert.Equal("Processing", progress[9].Description);
            Assert.Equal("Processed", progress[10].Description);
            Assert.Equal("Completed", progress[11].Description);

            var errors = progress.Where(p => p.Errors != null).SelectMany(p => p.Errors).ToList();
            Assert.Equal(1, errors.Count);
            Assert.Equal("ID: bad1, Error: Search provider error", errors[0]);


            // Do the same with batch size = 3
            progress.Clear();
            options.BatchSize = 3;

            await manager.IndexAsync(options, p => progress.Add(p), cancellationTokenSource.Token);

            Assert.Equal(6, progress.Count);
            Assert.Equal("Calculating documents count", progress[0].Description);
            Assert.Equal("Processing", progress[1].Description);
            Assert.Equal("Processed", progress[2].Description);
            Assert.Equal("Processing", progress[3].Description);
            Assert.Equal("Processed", progress[4].Description);
            Assert.Equal("Completed", progress[5].Description);

            errors = progress.Where(p => p.Errors != null).SelectMany(p => p.Errors).ToList();
            Assert.Equal(1, errors.Count);
            Assert.Equal("ID: bad1, Error: Search provider error", errors[0]);
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
