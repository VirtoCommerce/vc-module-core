using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;

namespace VirtoCommerce.CoreModule.Data.Services
{
    /// <summary>
    /// Represents sequence number generator using database storage and different policy.
    /// It generates an unique number using given template, e.g., "PO{0:yyMMdd}-{1:D5}" where
    /// 
    /// {0} - date (the UTC time of number generation)
    /// {1} - the sequence number
    /// {2} - tenantId
    /// 
    /// Also, it supports counter options after @:
    /// <numberTemplate> or <number_template>@<reset_counter_type>:<start_counter_from>:<counter_increment>
    /// 
    /// reset_counter_type - can be one of this value: None, Daily, Weekly, Monthly, Yearly. Default value: Daily
    /// start_counter_from - positive integer value. Default value: 1
    /// counter_increment - positive integer value. Default value: 1
    ///
    /// Examples:
    /// PO{1:D5}
    /// PO{0:yyMMdd}-{1:D5}
    /// PO{0:yyMMdd}-{1:D5}@Daily
    /// PO{0:yyMMdd}-{1:D5}@Weekly:1:10
    /// PO{0:yyMMdd}-{1:D5}@None:1:1
    /// </summary>
    public class SequenceNumberGeneratorService : IUniqueNumberGenerator, ITenantUniqueNumberGenerator
    {
        private readonly object _lock = new object();
        private readonly Func<ICoreRepository> _repositoryFactory;

        private readonly SequenceNumberGeneratorOptions _options;

        /// <summary>
        /// Creates new instance of SequenceUniqueNumberGeneratorService.
        /// </summary>
        /// <param name="repositoryFactory"></param>
        /// <param name="options"></param>
        public SequenceNumberGeneratorService(Func<ICoreRepository> repositoryFactory,
            IOptions<SequenceNumberGeneratorOptions> options)
        {
            ArgumentNullException.ThrowIfNull(repositoryFactory);
            ArgumentNullException.ThrowIfNull(options);

            _repositoryFactory = repositoryFactory;
            _options = options.Value;
        }

        /// <summary>
        /// Generates unique number using given template.
        /// </summary>
        /// <param name="numberTemplate">The number template. Pass the format to be used in string.Format function. Passable parameters: 0 - date (the UTC time of number generation); 1 - the sequence number.</param>
        /// <returns></returns>
        public virtual string GenerateNumber(string numberTemplate)
        {
            ArgumentNullException.ThrowIfNull(numberTemplate);

            var counterOptions = CounterOptions.Parse(numberTemplate);

            return GenerateNumber(string.Empty, counterOptions);
        }

        /// <summary>
        /// Generates unique number using given template.
        /// </summary>
        /// <param name="numberTemplate">The number template. Pass the format to be used in string.Format function. Passable parameters: 0 - date (the UTC time of number generation); 1 - the sequence number.</param>
        /// <returns></returns>
        public virtual string GenerateNumber(string tenantId, string numberTemplate)
        {
            ArgumentNullException.ThrowIfNull(tenantId);
            ArgumentNullException.ThrowIfNull(numberTemplate);

            var counterOptions = CounterOptions.Parse(numberTemplate);

            return GenerateNumber(tenantId, counterOptions);
        }

        /// <summary>
        /// Requests next counter and Generates unique number using given template and options for tenantId.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="numberTemplate"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public virtual string GenerateNumber(string tenantId, CounterOptions counterOptions)
        {
            ArgumentNullException.ThrowIfNull(tenantId);
            ArgumentNullException.ThrowIfNull(counterOptions);

            var retryPolicy = ConfigureRetryPolicy();

            lock (_lock)
            {
                var counter = 0;
                var currentDate = GetCurrentUtcDate();

                retryPolicy.Execute(() => counter = RequestNextCounter(tenantId, counterOptions));

                return GenerateNumberInternal(tenantId, counterOptions, currentDate, counter);
            }
        }

        /// <summary>
        /// Generates unique number using given params and options for tenantId.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="counterOptions"></param>
        /// <param name="currentDate"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        protected virtual string GenerateNumberInternal(string tenantId, CounterOptions counterOptions, DateTime currentDate, int counter)
        {
            return string.Format(counterOptions.NumberTemplate, currentDate, counter, tenantId);
        }

        /// <summary>
        /// Configures retry policy for database operations.
        /// </summary>
        /// <returns></returns>
        protected virtual RetryPolicy ConfigureRetryPolicy()
        {
            return Policy.Handle<DbUpdateConcurrencyException>()
                .Or<InvalidOperationException>()
                .WaitAndRetry(retryCount: _options.RetryCount, _ => TimeSpan.FromMilliseconds(_options.RetryDelay));
        }

        /// <summary>
        /// Requests next counter for given number template.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="numberTemplate"></param>
        /// <param name="counterOptions"></param>
        /// <returns></returns>
        protected virtual int RequestNextCounter(string tenantId, CounterOptions counterOptions)
        {
            var sequenceKey = GetSequenceKey(tenantId, counterOptions);

            using var repository = _repositoryFactory();
            var sequence = repository.Sequences.SingleOrDefault(s => s.ObjectType == sequenceKey);

            if (sequence != null)
            {
                var lastResetDate = sequence.ModifiedDate ?? GetCurrentUtcDate();

                if (ShouldResetCounter(lastResetDate, counterOptions.ResetCounterType))
                {
                    sequence.Value = counterOptions.StartCounterFrom;
                }
                else
                {
                    sequence.Value += counterOptions.CounterIncrement;
                }

                sequence.ModifiedDate = GetCurrentUtcDate();
            }
            else
            {
                sequence = new SequenceEntity
                {
                    ObjectType = sequenceKey,
                    Value = counterOptions.StartCounterFrom,
                    ModifiedDate = GetCurrentUtcDate()
                };
                repository.Add(sequence);
            }

            repository.UnitOfWork.Commit();

            return sequence.Value;
        }

        protected virtual string GetSequenceKey(string tenantId, CounterOptions counterOptions)
        {
            if(_options.UseGlobalTenantId)
            {
                tenantId = "__GlobalTenant";
            }

            return string.IsNullOrEmpty(tenantId) ?
                counterOptions.NumberTemplate :
                $"{tenantId}/{counterOptions.NumberTemplate}";
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
                    var daysUntilTargetDay = ((int)DayOfWeek.Monday - (int)lastResetDate.DayOfWeek + 7) % 7;
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
