using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.Platform.Core.Common;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class SequenceTests
    {
        private static readonly int _reservationCount = 4;
        private static readonly int _sequenceCountInReservation = SequenceUniqueNumberGeneratorServiceImpl.SequenceReservationRange;
        private static readonly string _sequenceTemplate = "{1}";

        public SequenceTests()
        {
        }

        [Fact]
        public void TestOrdersAreSequentialSingleThread()
        {
            var repositoryMocked = GetMockedRepository();
            var generator = new SequenceUniqueNumberGeneratorServiceImpl(() => repositoryMocked);

            var sequences = new string[_reservationCount * _sequenceCountInReservation];
            for (var i = 0; i < sequences.Length; i++)
            {
                sequences[i] = generator.GenerateNumber(_sequenceTemplate);
            }

            AssertSequences(_reservationCount, sequences);
        }

        [Fact]
        public async Task TestOrdersAreSequentialMultipleThreads()
        {
            var repositoryMocked = GetMockedRepository();

            var sequences = new ConcurrentQueue<string>();
            var tasks = new Task[_reservationCount];
            using (var countdownEvent = new CountdownEvent(_reservationCount))
            {
                for (var i = 0; i < _reservationCount; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        var generator = new SequenceUniqueNumberGeneratorServiceImpl(() => repositoryMocked);
                        var oneSequenceArray = new string[_sequenceCountInReservation];
                        for (var j = 0; j < oneSequenceArray.Length; j++)
                        {
                            // All threads start pregeneration simultaneously to create real concurrency.
                            if (j == 0)
                            {
                                countdownEvent.Signal();
                                countdownEvent.Wait();
                            }
                            sequences.Enqueue(generator.GenerateNumber(_sequenceTemplate));
                        }
                    });
                }
                await Task.WhenAll(tasks);
            }

            var flattenList = sequences.ToList();
            AssertSequences(_reservationCount, flattenList);
        }

        private static void AssertSequences(int reservationCount, IList<string> flattenList)
        {
            Assert.Equal(reservationCount * _sequenceCountInReservation, flattenList.Count);
            var previous = 0;
            var current = 0;

            // Check if collection consists of sequential integers.
            for (var i = 1; i < flattenList.Count; i++)
            {
                Assert.True(int.TryParse(flattenList[i - 1], out previous) && int.TryParse(flattenList[i], out current));
                Assert.Equal(1, current - previous);
            }
        }

        private ICommerceRepository GetMockedRepository()
        {
            var mockRepository = new Mock<ICommerceRepository>();
            var sequenceCollection = new List<Sequence>();
            mockRepository.Setup(x => x.Sequences).Returns(sequenceCollection.AsQueryable());
            mockRepository.Setup(x => x.Add(It.IsAny<Sequence>())).Callback((Sequence s) => { sequenceCollection.Add(s); });
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.UnitOfWork).Returns(() => mockUnitOfWork.Object);
            return mockRepository.Object;
        }
    }
}
