using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;

namespace VirtoCommerce.CoreModule.Data.Services
{
    /// <summary>
    /// Represents implementation of unique number generator using database sequences.
    /// Generates unique number using given template, e.g., GenerateNumber("Order{0:yyMMdd}-{1:D5}");
    /// {0} - date (the UTC time of number generation)
    /// {1} - the sequence number
    /// {2} - tenantId
    /// </summary>
    public class SequenceUniqueNumberGeneratorService : IUniqueNumberGenerator, ITenantUniqueNumberGenerator
    {
        private readonly object _lock = new object();
        private readonly Func<ICoreRepository> _repositoryFactory;

        /// <summary>
        /// Creates new instance of SequenceUniqueNumberGeneratorService.
        /// </summary>
        /// <param name="repositoryFactory"></param>
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
            return GenerateNumber(string.Empty, numberTemplate,
                new UniqueNumberGeneratorOptions
                {
                    ResetCounterType = ResetCounterType.Daily,
                    CounterIncrement = 1,
                    StartCounterFrom = 1
                });
        }

        /// <summary>
        /// Generates unique number using given template and options for tentantId.
        /// </summary>
        /// <param name="tentantId"></param>
        /// <param name="numberTemplate"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string GenerateNumber(string tentantId, string numberTemplate, UniqueNumberGeneratorOptions options)
        {
            var retryPolicy = ConfigureRetryPolicy();

            lock (_lock)
            {
                var currentDate = DateTime.Now;
                var counter = 0;

                retryPolicy.Execute(() => counter = RequestNextCounter(tentantId, numberTemplate, options));

                return string.Format(numberTemplate, currentDate, counter, tentantId);
            }
        }

        /// <summary>
        /// Configures retry policy for database operations.
        /// </summary>
        /// <returns></returns>
        protected virtual RetryPolicy ConfigureRetryPolicy()
        {
            return Policy.Handle<DbUpdateConcurrencyException>()
                .Or<InvalidOperationException>()
                .WaitAndRetry(retryCount: 15, _ => TimeSpan.FromMilliseconds(5));
        }

        /// <summary>
        /// Requests next counter for given number template.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="numberTemplate"></param>
        /// <param name="resetCounterType"></param>
        /// <returns></returns>
        protected virtual int RequestNextCounter(string tenantId, string numberTemplate, UniqueNumberGeneratorOptions options)
        {
            using var repository = _repositoryFactory();
            var sequence = repository.Sequences.SingleOrDefault(s => s.ObjectType == numberTemplate);

            if (sequence != null)
            {
                var lastResetDate = sequence.ModifiedDate ?? GetCurrentUtcDate();

                if (ShouldResetCounter(lastResetDate, options.ResetCounterType))
                {
                    sequence.Value = options.StartCounterFrom;
                }
                else
                {
                    sequence.Value += options.CounterIncrement;
                }

                sequence.ModifiedDate = GetCurrentUtcDate();
            }
            else
            {
                sequence = new SequenceEntity
                {
                    ObjectType = numberTemplate,
                    Value = options.StartCounterFrom,
                    ModifiedDate = GetCurrentUtcDate()
                };
                repository.Add(sequence);
            }

            repository.UnitOfWork.Commit();

            return sequence.Value;
        }

        /// <summary>
        /// Returns true if counter should be reset.
        /// </summary>
        /// <param name="lastResetDate"></param>
        /// <param name="resetCounterType"></param>
        /// <returns></returns>
        protected virtual bool ShouldResetCounter(DateTime lastResetDate, ResetCounterType resetCounterType)
        {
            var currentUtcDate = GetCurrentUtcDate();

            switch (resetCounterType)
            {
                case ResetCounterType.Daily:
                    return currentUtcDate.Date > lastResetDate.Date;
                case ResetCounterType.Weekly:
                    // Reset every Monday
                    int daysUntilTargetDay = ((int)DayOfWeek.Monday - (int)lastResetDate.DayOfWeek + 7) % 7;
                    var nextMondayDate = lastResetDate.Date.AddDays(daysUntilTargetDay);
                    return currentUtcDate >= nextMondayDate;
                case ResetCounterType.Monthly:
                    // Reset on first day of the month
                    return currentUtcDate.Month > lastResetDate.Month || currentUtcDate.Year > lastResetDate.Year;
                case ResetCounterType.Yearly:
                    // Reset on first day of the year 
                    return currentUtcDate.Year > lastResetDate.Year;
                case ResetCounterType.None:
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns current UTC date. Allows to override for testing purposes.
        /// </summary>
        /// <returns></returns>
        protected virtual DateTime GetCurrentUtcDate()
        {
            return DateTime.UtcNow;
        }
    }
}
