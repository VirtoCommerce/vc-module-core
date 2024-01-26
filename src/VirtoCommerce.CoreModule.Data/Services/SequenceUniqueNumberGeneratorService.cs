using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Polly;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;

namespace VirtoCommerce.CoreModule.Data.Services
{
    public class SequenceUniqueNumberGeneratorService : IUniqueNumberGenerator
    {
        private readonly object _lock = new object();
        private readonly Func<ICoreRepository> _repositoryFactory;

        public SequenceUniqueNumberGeneratorService(Func<ICoreRepository> repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Generates unique number using given template, e.g., GenerateNumber("Order{0:yyMMdd}-{1:D5}");
        /// </summary>
        /// <param name="numberTemplate">The number template. Pass the format to be used in string.Format function. Passable parameters: 0 - date (the UTC time of number generation); 1 - the sequence number.</param>
        /// <returns></returns>
        public string GenerateNumber(string numberTemplate)
        {
            var retryPolicy = Policy.Handle<DbUpdateConcurrencyException>().WaitAndRetry(retryCount: 10, _ => TimeSpan.FromMilliseconds(5));

            lock (_lock)
            {
                var currentDate = DateTime.Now; // {0}

                int counter = 0;
                retryPolicy.Execute(() => counter = RequestNextCounter(numberTemplate));

                return string.Format(numberTemplate, currentDate, counter);
            }
        }

        protected virtual int RequestNextCounter(string numberTemplate)
        {
            using var repository = _repositoryFactory();
            var sequence = repository.Sequences.SingleOrDefault(s => s.ObjectType == numberTemplate);

            if (sequence != null)
            {
                sequence.ModifiedDate = DateTime.UtcNow;
                sequence.Value += 1;
            }
            else
            {
                sequence = new SequenceEntity { ObjectType = numberTemplate, Value = 1, ModifiedDate = DateTime.UtcNow };
                repository.Add(sequence);
            }

            repository.UnitOfWork.Commit();

            return sequence.Value;
        }
    }
}
