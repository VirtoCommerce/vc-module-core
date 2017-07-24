using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.Domain.Common;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    // [Trait("Category", "CI")]
    public class NumberGeneratorTests
    {
        [Fact]
        public void ShouldBeAbleToGenerateUniqueNumbersAsync()
        {
            // assume there will be several (3) instances. Have to comment out the line 
            // lock (_sequenceLock)
            // in SequenceUniqueNumberGeneratorServiceImpl to cause deadlocks.
            var tasks = new[] {
                Task.Factory.StartNew(GenerateNumber),
                Task.Factory.StartNew(GenerateNumber),
                Task.Factory.StartNew(GenerateNumber)
            };

            Task.WaitAll(tasks);
            var allNumbers = tasks.Select(x => x.Result).ToArray();
            var uniqueCount = allNumbers.Distinct().Count();
            Assert.Equal(allNumbers.Length, uniqueCount);
        }

        public string GenerateNumber()
        {
            return GetNumberGeneratorService().GenerateNumber("test{0:yyMMdd}-{1:D5}");
        }

        private IUniqueNumberGenerator GetNumberGeneratorService()
        {
            return new SequenceUniqueNumberGeneratorServiceImpl(GetСommerceRepository);
        }

        private static IСommerceRepository GetСommerceRepository()
        {
            return new CommerceRepositoryImpl("VirtoCommerce");
        }
    }
}