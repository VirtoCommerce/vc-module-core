namespace VirtoCommerce.CoreModule.Core.Common
{
    /// <summary>
    /// Represents counter options for ITenantUniqueNumberGenerator.
    /// </summary>
    public class CounterOptions
    {
        /// <summary>
        /// Represents type of counter reset. Can be one of this value: None, Daily, Weekly, Monthly, Yearly. Default value: Daily  
        /// </summary>
        public ResetCounterType ResetCounterType { get; set; } = ResetCounterType.Daily;
        /// <summary>
        /// Represents start counter from value. Default value: 1
        /// </summary>
        public int StartCounterFrom { get; set; } = 1;
        /// <summary>
        /// Represents counter increment value. Default value: 1
        /// </summary>
        public int CounterIncrement { get; set; } = 1;
    }
}
