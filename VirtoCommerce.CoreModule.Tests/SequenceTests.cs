using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Moq;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Platform.Core.Common;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class SequenceTests
    {
        private readonly IUnityContainer _unity = new UnityContainer();
        private static readonly int _reservationCount = 4;
        private static readonly int _sequenceCountInReservation = SequenceUniqueNumberGeneratorServiceImpl.SequenceReservationRange;

        public SequenceTests()
        {
            PrepareContext();
        }

        [Fact]
        public void TestOrdersAreSequentialSingleThread()
        {
            var generator = _unity.Resolve<ISequenceInvoker>();

            var sequences = new string[_reservationCount * _sequenceCountInReservation];
            for (var i = 0; i < sequences.Length; i++)
            {
                sequences[i] = generator.GetNextValue();
            }

            AssertSequences(_reservationCount, sequences);
        }

        [Fact]
        public async Task TestOrdersAreSequentialMultipleThreads()
        {
            var sequences = new ConcurrentQueue<string>();
            var tasks = new Task[_reservationCount];
            using (var countdownEvent = new CountdownEvent(_reservationCount))
            {
                for (var i = 0; i < _reservationCount; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        var generator = _unity.Resolve<ISequenceInvoker>();
                        var oneSequenceArray = new string[_sequenceCountInReservation];
                        for (var j = 0; j < oneSequenceArray.Length; j++)
                        {
                            // All threads start pregeneration simultaneously to create real concurrency.
                            if (j == 0)
                            {
                                countdownEvent.Signal();
                                countdownEvent.Wait();
                            }
                            sequences.Enqueue(generator.GetNextValue());
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

        #region Context creation

        private void PrepareContext()
        {
            var repositoryMocked = GetMockedRepository();
            InjectDependencies(repositoryMocked);
        }

        private void InjectDependencies(ICommerceRepository repositoryMocked)
        {
            _unity.RegisterInstance<Func<ICommerceRepository>>(() => repositoryMocked);
            _unity.RegisterType<IUniqueNumberGenerator, SequenceUniqueNumberGeneratorServiceImpl>();
            _unity.RegisterType<ISequenceInvoker, NumberSequenceInvoker>();
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

        #endregion

        #region Inner classes used in test

        interface ISequenceInvoker
        {
            string GetNextValue();
        }

        class NumberSequenceInvoker : ISequenceInvoker
        {
            private readonly IUniqueNumberGenerator _generator;

#pragma warning disable S1144
            public NumberSequenceInvoker(IUniqueNumberGenerator generator)
            {
                _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            }
#pragma warning restore S1144

            public string GetNextValue()
            {
                return _generator.GenerateNumber("{1}");
            }
        }

        #endregion
    }
}
