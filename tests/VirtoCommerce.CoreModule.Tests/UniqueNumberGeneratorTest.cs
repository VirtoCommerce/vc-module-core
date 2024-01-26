using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.Platform.Core.Domain;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class CustomDateSequenceUniqueNumberGeneratorService : SequenceUniqueNumberGeneratorService
    {
        public DateTime CurrentUtcDate { get; set; }

        public CustomDateSequenceUniqueNumberGeneratorService(Func<ICoreRepository> repositoryFactory,
            DateTime currentUtcDate) : base(repositoryFactory, Options.Create(new SequenceNumberGeneratorOptions()))
        {
            CurrentUtcDate = currentUtcDate;
        }

        protected override DateTime GetCurrentUtcDate()
        {
            return CurrentUtcDate;
        }
    }

    public class UniqueNumberGeneratorTest
    {
        [Fact]
        [Trait("Category", "IntegrationTest")]
        public void IntegrationTestWithSqlServer()
        {
            var connectionString = "Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;Connect Timeout=30;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var generator = new SequenceUniqueNumberGeneratorService(() => new CoreRepositoryImpl(new CoreDbContext(optionsBuilder.Options)),
                Options.Create(new SequenceNumberGeneratorOptions()));

            var number = generator.GenerateNumber("PO{0:yyMMdd}-{1:D5}");
            Assert.NotNull(number);
        }

        [Theory]
        [InlineData("{1}", "2")]
        [InlineData("PO-{1:D5}", "PO-00002")]
        [InlineData("CO{0:yyMMdd}-{1:D5}", "CO240126-00002")]
        public void GenerateNumber_ShouldGenerateUniqueNumbersWithDifferentParameters(string template, string expected)
        {
            // Arrange
            var sequenceEntity = new SequenceEntity { ObjectType = template, Value = 1, ModifiedDate = DateTime.UtcNow };

            var repositoryFactoryMock = CreateRepositoryMock(sequenceEntity);

            var numberGeneratorService = new CustomDateSequenceUniqueNumberGeneratorService(
                repositoryFactoryMock.Object,
                new DateTime(2024, 01, 26, 0, 0, 0, DateTimeKind.Utc));

            // Act
            var generatedNumber = numberGeneratorService.GenerateNumber(template);

            // Assert
            Assert.Equal(expected, generatedNumber);
        }



        public static TheoryData<DateTime, DateTime, ResetCounterType, string> ResetCounterCases =
            new()
            {
                // Daily
                {
                    new DateTime(2024, 01, 26, 23, 59, 58, DateTimeKind.Utc),
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Daily,
                    "00778"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2024, 01, 27, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Daily,
                    "00001"
                },
                // Weekly
                {
                    new DateTime(2024, 01, 26, 23, 59, 58, DateTimeKind.Utc),
                    new DateTime(2024, 01, 28, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Weekly,
                    "00778"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2024, 01, 29, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Weekly,
                    "00001"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2024, 01, 30, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Weekly,
                    "00001"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2024, 05, 30, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Weekly,
                    "00001"
                },
                // Monthly
                {
                    new DateTime(2024, 01, 26, 23, 59, 58, DateTimeKind.Utc),
                    new DateTime(2024, 01, 31, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Monthly,
                    "00778"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2024, 02, 01, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Monthly,
                    "00001"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2025, 01, 01, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Monthly,
                    "00001"
                },
                // Yearly
                 {
                    new DateTime(2024, 01, 26, 23, 59, 58, DateTimeKind.Utc),
                    new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Yearly,
                    "00778"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2025, 02, 01, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.Yearly,
                    "00001"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2030, 01, 01, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.Yearly,
                    "00001"
                },
                // Never
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2025, 02, 01, 00, 00, 00, DateTimeKind.Utc),
                    ResetCounterType.None,
                    "00778"
                },
                {
                    new DateTime(2024, 01, 26, 23, 59, 59, DateTimeKind.Utc),
                    new DateTime(2030, 01, 01, 23, 59, 59, DateTimeKind.Utc),
                    ResetCounterType.None,
                    "00778"
                },
            };


        [Theory]
        [MemberData(nameof(ResetCounterCases))]
        public void GenerateNumber_ResetCounter(DateTime lastResetDate, DateTime currentDate, ResetCounterType resetCounterType, string expected)
        {
            var tenantId = "TEST";
            var template = "{1:D5}";

            // Arrange
            var sequenceEntity = new SequenceEntity { ObjectType = template, Value = 777, ModifiedDate = lastResetDate };

            var repositoryFactoryMock = CreateRepositoryMock(sequenceEntity);

            var numberGeneratorService = new CustomDateSequenceUniqueNumberGeneratorService(
                repositoryFactoryMock.Object,
                currentDate);

            // Act
            var generatedNumber = numberGeneratorService.GenerateNumber(tenantId, template,
                new UniqueNumberGeneratorOptions { ResetCounterType = resetCounterType });

            // Assert
            Assert.Equal(expected, generatedNumber);
        }

        private static Mock<Func<ICoreRepository>> CreateRepositoryMock(SequenceEntity sequenceEntity)
        {
            var repositoryMock = new Mock<ICoreRepository>();
            repositoryMock.Setup(r => r.Sequences).Returns((new SequenceEntity[] { sequenceEntity }).AsQueryable());
            repositoryMock.Setup(r => r.UnitOfWork).Returns((new Mock<IUnitOfWork>()).Object);

            var repositoryFactoryMock = new Mock<Func<ICoreRepository>>();
            repositoryFactoryMock.Setup(f => f()).Returns(repositoryMock.Object);
            return repositoryFactoryMock;
        }
    }
}
