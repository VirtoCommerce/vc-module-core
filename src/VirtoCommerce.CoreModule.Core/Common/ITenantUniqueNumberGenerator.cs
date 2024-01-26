namespace VirtoCommerce.CoreModule.Core.Common
{
    /// <summary>
    /// Represents options for unique number generation.
    /// </summary>
    public class UniqueNumberGeneratorOptions
    {
        public ResetCounterType ResetCounterType { get; set; }
        public int StartCounterFrom { get; set; } = 1;
        public int CounterIncrement { get; set; } = 1;
    }

    /// <summary>
    /// Represents interface for unique number generation for tenant.
    /// </summary>
    public interface ITenantUniqueNumberGenerator
    {
        /// <summary>
        /// Generates unique number using given template with resetCounterType for tentantId.
        /// </summary>
        /// <param name="tentantId"></param>
        /// <param name="numberTemplate"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        string GenerateNumber(string tentantId, string numberTemplate, UniqueNumberGeneratorOptions options);
    }
}
