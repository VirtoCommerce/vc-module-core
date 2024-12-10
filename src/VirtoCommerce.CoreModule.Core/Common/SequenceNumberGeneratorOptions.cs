namespace VirtoCommerce.CoreModule.Core.Common
{
    public class SequenceNumberGeneratorOptions
    {
        /// <summary>
        /// Defines the number of retries to generate unique number if either DbUpdateConcurrencyException or InvalidOperationException is occured.
        /// </summary>
        public int RetryCount { get; set; } = 15;
        /// <summary>
        /// Defines the delay between retries in seconds.
        /// </summary>
        public int RetryDelay { get; set; } = 5;

        /// <summary>
        /// Defines usage of the static tenant id instead of store id for generating unique number.
        /// Can be useful when you want to have golobal counter for all stores/tenants.
        /// </summary>
        public bool UseGlobalTenantId { get; set; } = false;
    }
}
