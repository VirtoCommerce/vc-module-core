namespace VirtoCommerce.CoreModule.Core.Common
{
    /// <summary>
    /// Represents interface for unique number generation for tenant.
    /// </summary>
    public interface ITenantUniqueNumberGenerator
    {
        /// <summary>
        /// Generates unique number using given template with resetCounterType for tentantId.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="counterOptions"></param>
        /// <returns></returns>
        string GenerateNumber(string tenantId, CounterOptions counterOptions);

        /// <summary>
        /// Generates unique number using given template for tentantId.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="numberTemplate"></param>
        /// <returns></returns>
        string GenerateNumber(string tenantId, string numberTemplate);
    }
}
