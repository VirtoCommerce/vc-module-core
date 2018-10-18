using System;
using System.Collections.Generic;

namespace VirtoCommerce.Domain.Pricing.Services
{
    /// <summary>
    /// Service responsible for providing changes for the prices that are not caused by user changes.
    /// </summary>
    public interface IPricingChangesService
    {
        /// <summary>
        /// Returns all price changes due to date filtering.
        /// </summary>
        /// <param name="lastEvaluationTimestamp">Last time this evaluation was called, if null, beginning of time will be used.</param>
        /// <param name="evaluationTimestamp">Moment to evaluate, if null, UTC now is used.</param>
        /// <param name="skip">Optional pagination.</param>
        /// <param name="take">Optional pagination.</param>
        /// <returns>Stream of changes.</returns>
        IEnumerable<Model.PriceCalendarChange> GetCalendarChanges(DateTime? lastEvaluationTimestamp,
            DateTime? evaluationTimestamp, int? skip = null, int? take = null);
    }
}
