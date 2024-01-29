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
    public class CustomDateSequenceUniqueNumberGeneratorService : SequenceNumberGeneratorService
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

    public class NumberGeneratorTest
    {
        [Fact]
        [Trait("Category", "IntegrationTest")]
        public void IntegrationTestWithSqlServer()
        {
            var connectionString = "Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;Connect Timeout=30;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var generator = new SequenceNumberGeneratorService(() => new CoreRepositoryImpl(new CoreDbContext(optionsBuilder.Options)),
                Options.Create(new SequenceNumberGeneratorOptions()));

            var number = generator.GenerateNumber("PO{0:yyMMdd}-{1:D5}");
            Assert.NotNull(number);
        }

        [Theory]
        [InlineData("{1}", "{1}", ResetCounterType.Daily, 1, 1)]
        [InlineData("PO-{1:D5}", "PO-{1:D5}", ResetCounterType.Daily, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Daily, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.None, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Daily", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Daily, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Weekly", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Weekly, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Monthly", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Monthly, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Yearly", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Yearly, 1, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:5", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.None, 5, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Daily:55", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Daily, 55, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Weekly:555", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Weekly, 555, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Monthly:5555", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Monthly, 5555, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Yearly:55555", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Yearly, 55555, 1)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:5:8", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.None, 5, 8)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Daily:55:88", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Daily, 55, 88)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Weekly:555:888", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Weekly, 555, 888)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Monthly:5555:8888", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Monthly, 5555, 8888)]
        [InlineData("CO{0:yyMMdd}-{1:D5}@Yearly:55555:88888", "CO{0:yyMMdd}-{1:D5}", ResetCounterType.Yearly, 55555, 88888)]
        public void GenerateNumber_ShouldParseCounterOptionsWithDifferentParameters(string template,
            string numberTemplate, ResetCounterType resetCounterType, int startCounterFrom, int counterIncrement)
        {
            var counterOptions = CounterOptions.Parse(template);

            // Assert
            Assert.Equal(numberTemplate, counterOptions.NumberTemplate);
            Assert.Equal(resetCounterType, counterOptions.ResetCounterType);
            Assert.Equal(startCounterFrom, counterOptions.StartCounterFrom);
            Assert.Equal(counterIncrement, counterOptions.CounterIncrement);
        }

        [Theory]
        [InlineData("{1}", "778")]
        [InlineData("PO-{1:D5}", "PO-00778")]
        [InlineData("CO{0:yyMMdd}-{1:D5}", "CO240126-00778")]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None", "CO240126-00778")]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:1", "CO240126-00778")]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:1:1", "CO240126-00778")]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:1:10", "CO240126-00787")]
        [InlineData("CO{0:yyMMdd}-{1:D5}@None:1:100", "CO240126-00877")]
        public void GenerateNumber_ShouldGenerateUniqueNumbersWithDifferentParameters(string template, string expected)
        {
            var objectType = template.Contains("@") ? template.Substring(0, template.IndexOf("@")) : template;
            // Arrange
            var sequenceEntity = new SequenceEntity { ObjectType = objectType, Value = 777, ModifiedDate = DateTime.UtcNow };

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
            var sequenceEntity = new SequenceEntity { ObjectType = $"{tenantId}/{template}", Value = 777, ModifiedDate = lastResetDate };

            var repositoryFactoryMock = CreateRepositoryMock(sequenceEntity);

            var numberGeneratorService = new CustomDateSequenceUniqueNumberGeneratorService(
                repositoryFactoryMock.Object,
                currentDate);

            // Act
            var generatedNumber = numberGeneratorService.GenerateNumber(
                tenantId,
                new CounterOptions
                {
                    NumberTemplate = template,
                    ResetCounterType = resetCounterType
                });

            // Assert
            Assert.Equal(expected, generatedNumber);
        }

        [Theory]
        [MemberData(nameof(ResetCounterCases))]
        public void GenerateNumber_ResetCounter_LoadSettingsFromTemplate(DateTime lastResetDate, DateTime currentDate, ResetCounterType resetCounterType, string expected)
        {
            var tenantId = "TEST";
            var template = "{1:D5}";

            // Arrange
            var sequenceEntity = new SequenceEntity { ObjectType = $"{tenantId}/{template}", Value = 777, ModifiedDate = lastResetDate };

            var repositoryFactoryMock = CreateRepositoryMock(sequenceEntity);

            var numberGeneratorService = new CustomDateSequenceUniqueNumberGeneratorService(
                repositoryFactoryMock.Object,
                currentDate);

            // Act
            var generatedNumber = numberGeneratorService.GenerateNumber(tenantId, $"{template}@{resetCounterType}");

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
