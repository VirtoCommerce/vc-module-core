using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Moq;
using VirtoCommerce.CoreModule.Core.NumberGenerators;
using VirtoCommerce.CoreModule.Data.NumberGenerators;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Domain;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class RepositorySequencesTest
    {
        private readonly ICoreRepository _repository;
        private readonly Func<ICoreRepository> _repositoryFactory;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IPlatformMemoryCache> _platformMemoryCacheMock;
        private readonly Mock<ICacheEntry> _cacheEntryMock;
        private readonly NumberGeneratorService _generatorService;
        private const string _tenantId = "testTenant";
        private const string _targetType = "testType";
        private const string _template = "test{1:yyMMdd}-{0:D5}";

        public RepositorySequencesTest()
        {
            _repository = new CoreRepositoryImpl(new CoreDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CoreDbContext>()));
            _repositoryFactory = () => _repository;
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _platformMemoryCacheMock = new Mock<IPlatformMemoryCache>();
            _cacheEntryMock = new Mock<ICacheEntry>();
            _cacheEntryMock.SetupGet(c => c.ExpirationTokens).Returns(new List<IChangeToken>());

            _generatorService = new NumberGeneratorService(_repositoryFactory, _platformMemoryCacheMock.Object);
            var cacheKey = CacheKey.With(_generatorService.GetType(), nameof(_generatorService.GetAsync), _tenantId);
            _platformMemoryCacheMock.Setup(pmc => pmc.CreateEntry(cacheKey)).Returns(_cacheEntryMock.Object);

        }

        [Fact]
        public async Task SaveChangesAsync_ShouldSaveDescriptor()
        {
            //Arrange
            var testDescriptors = new[] { new NumberGeneratorDescriptor { TargetType = _targetType, TenantId = _tenantId, Template = _template } };

            //Act
            await _generatorService.SaveChangesAsync(testDescriptors);
        }
    }
}
