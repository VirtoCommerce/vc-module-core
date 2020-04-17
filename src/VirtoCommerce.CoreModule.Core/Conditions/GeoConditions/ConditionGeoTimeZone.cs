using TimeZoneConverter;
using VirtoCommerce.CoreModule.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions.GeoConditions
{
    //Browsing from a time zone -/+ offset from UTC 
    public class ConditionGeoTimeZone : CompareConditionBase
    {
        public string Value { get; set; }
        public string SecondValue { get; set; }

        public override bool IsSatisfiedBy(IEvaluationContext context)
        {
            var result = false;
            if (context is EvaluationContextBase evaluationContext && !string.IsNullOrEmpty(evaluationContext.GeoTimeZone) && !string.IsNullOrEmpty(Value))
            {
                var geoTimeZone = TZConvert.GetTimeZoneInfo(evaluationContext.GeoTimeZone).BaseUtcOffset.TotalMilliseconds;
                var valueTimeZone = TZConvert.GetTimeZoneInfo(Value).BaseUtcOffset.TotalMilliseconds;
                var secondValueTimeZone = !string.IsNullOrEmpty(SecondValue) ? TZConvert.GetTimeZoneInfo(SecondValue).BaseUtcOffset.TotalMilliseconds : 0;

                result = UseCompareCondition(geoTimeZone, valueTimeZone, secondValueTimeZone);
            }

            return result;
        }
    }
}
