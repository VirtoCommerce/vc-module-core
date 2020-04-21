using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Core.Conditions;
using VirtoCommerce.CoreModule.Core.Conditions.GeoConditions;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class ConditionUnitTest
    {
        [Theory]
        [ClassData(typeof(TimeZoneTestData))]
        public void ConditionGeoTimeZone_IsSatisfiedBy(string currenTimeZone, string compareCondition, string valueCondition, string secondValueCondition)
        {
            //Arrange
            var evaluationContext = new SomeContext
            {
                GeoTimeZone = currenTimeZone
            };
            var condition = new ConditionGeoTimeZone
            {
                CompareCondition = compareCondition,
                Value = valueCondition,
                SecondValue = secondValueCondition
            };

            //Act
            var result = condition.IsSatisfiedBy(evaluationContext);

            //Assert
            Assert.True(result);
        }
    }

    public class SomeContext: EvaluationContextBase
    {
        
    }

    public class TimeZoneTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Europe/Kaliningrad", ConditionOperation.AtLeast, "Europe/Kaliningrad", null };
            yield return new object[] { "Europe/Kaliningrad", ConditionOperation.IsMatching, "Europe/Kaliningrad", null };
            yield return new object[] { "Europe/Kaliningrad", ConditionOperation.IsNotMatching, "CET", null };
            yield return new object[] { "Europe/Kaliningrad", ConditionOperation.Between, "CET", "Etc/GMT-3" };
            yield return new object[] { "Europe/Kaliningrad", ConditionOperation.IsGreaterThan, "CET", string.Empty };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
