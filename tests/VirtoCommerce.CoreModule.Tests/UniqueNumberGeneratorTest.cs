using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using VirtoCommerce.CoreModule.Core.Services;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.NumberGenerators;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Domain;

namespace VirtoCommerce.CoreModule.Tests
{
    public class UniqueNumberGeneratorTest
    {
        private readonly List<NumberGeneratorDescriptorEntity> _mockGeneratorDescriptors;
        private readonly Mock<ICoreRepository> _repositoryMock;
        private readonly Func<ICoreRepository> _repositoryFactory;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly INumberGeneratorRegistrar _registrar;
        private readonly Mock<IPlatformMemoryCache> _platformMemoryCacheMock;
        private readonly Mock<ICacheEntry> _cacheEntryMock;
        private readonly NumberGeneratorService _generatorService;
        private const string _tenantId = "testTenant";
        private const string _targetType = "testType";
        private const string _template = "test{1:yyMMdd}-{0:D5}";

        //public UniqueNumberGeneratorTest()
        //{
        //    _repositoryMock = new Mock<ICoreRepository>();
        //    _repositoryFactory = () => _repositoryMock.Object;
        //    _mockUnitOfWork = new Mock<IUnitOfWork>();
        //    _repositoryMock.Setup(ss => ss.UnitOfWork).Returns(_mockUnitOfWork.Object);
        //    _mockGeneratorDescriptors = new List<NumberGeneratorDescriptorEntity> { new NumberGeneratorDescriptorEntity { TargetType = _targetType, TenantId = _tenantId, Template = _template } };

        //    _repositoryMock.Setup(ss => ss.NumberGenerators).Returns(_mockGeneratorDescriptors.AsQueryable());
        //    //_repositoryMock.Setup(ss => ss.NumberGenerators).Returns(Task.FromResult(_mockGeneratorDescriptors));
        //    _platformMemoryCacheMock = new Mock<IPlatformMemoryCache>();
        //    _cacheEntryMock = new Mock<ICacheEntry>();
        //    _cacheEntryMock.SetupGet(c => c.ExpirationTokens).Returns(new List<IChangeToken>());

        //    _generatorService = new NumberGeneratorService(_repositoryFactory, _platformMemoryCacheMock.Object);
        //    var cacheKey = CacheKey.With(_generatorService.GetType(), nameof(_generatorService.GetAsync), _tenantId);
        //    _platformMemoryCacheMock.Setup(pmc => pmc.CreateEntry(cacheKey)).Returns(_cacheEntryMock.Object);

        //    _registrar = new NumberGeneratorRegistrar();
        //    _registrar.RegisterType(_targetType, new Core.NumberGenerators.NumberGeneratorDescriptor { TargetType = _targetType, TenantId = _tenantId, Template = _template });
        //}

        //[Fact]
        //public async Task SqlSequenceNumberGenerator_ShouldUseNextValue()
        //{
        //    //Arrange
        //    var generator = new SqlSequenceNumberGenerator(_repositoryFactory, _generatorService, _registrar);

        //    //Act
        //    var result = await generator.GenerateNumber(_tenantId, _targetType);

        //    //Assert
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public async Task SqlSequenceNumberGenerator_ShouldUseRegistrarData()
        //{
        //    //Arrange
        //    _mockGeneratorDescriptors.Clear();
        //    var generator = new SqlSequenceNumberGenerator(_repositoryFactory, _generatorService, _registrar);

        //    //Act
        //    var result = await generator.GenerateNumber(_tenantId, _targetType);

        //    //Assert
        //    Assert.NotNull(result);
        //}
    }
}
