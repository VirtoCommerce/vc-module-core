using System;
using System.Text.RegularExpressions;

namespace VirtoCommerce.CoreModule.Core.Common
{
    /// <summary>
    /// Represents counter options for ITenantUniqueNumberGenerator.
    /// </summary>
    public class CounterOptions
    {
        private static Regex NumberTemplateRegex = new Regex(@"(?<Template>[^@]+)@(?<ResetCounterType>None|Daily|Weekly|Monthly|Yearly)(:(?<StartCounterFrom>\d+))?(:(?<CounterIncrement>\d+))?", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        /// <summary>
        /// Represents number temp[late 
        /// </summary>
        public string NumberTemplate { get; set; }

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

        public override string ToString()
        {
            return $"{NumberTemplate}@{ResetCounterType}:{StartCounterFrom}:{CounterIncrement}";
        }

        /// <summary>
        /// Parse counter options from string template: "numberTemplate" or "number_template@reset_counter_type:start_counter_from:counter_increment".
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static CounterOptions Parse(string template)
        {
            ArgumentNullException.ThrowIfNull(template);

            var match = NumberTemplateRegex.Match(template);

            if (match.Success)
            {
                return new CounterOptions
                {
                    NumberTemplate = match.Groups["Template"].Value,
                    ResetCounterType = Enum.Parse<ResetCounterType>(match.Groups["ResetCounterType"].Value),
                    StartCounterFrom = string.IsNullOrEmpty(match.Groups["StartCounterFrom"].Value) ? 1 : int.Parse(match.Groups["StartCounterFrom"].Value),
                    CounterIncrement = string.IsNullOrEmpty(match.Groups["CounterIncrement"].Value) ? 1 : int.Parse(match.Groups["CounterIncrement"].Value),
                };
            }
            else
            {
                return new CounterOptions { NumberTemplate = template };
            }
        }
    }
}
