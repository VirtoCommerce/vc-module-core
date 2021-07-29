using System;
using System.Collections.Generic;
using VirtoCommerce.CoreModule.Core.Currency;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class DefaultMoneyRoundingPolicyTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CanRound(decimal amount, decimal expected, RoundingType roundingType, MidpointRounding midpointRounding)
        {
            // Arrange
            var roundPolicy = new DefaultMoneyRoundingPolicy();
            var currency = new Currency();
            currency.RoundingType = roundingType;
            currency.MidpointRounding = midpointRounding;

            // Act
            var result = roundPolicy.RoundMoney(amount, currency);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                // AwayFromZero
                new object[] { 1.005m, 1.01m, RoundingType.Rounding001, MidpointRounding.AwayFromZero},
                new object[] { 1.004m, 1m, RoundingType.Rounding001, MidpointRounding.AwayFromZero},
                new object[] { 1.0009m, 1m, RoundingType.Rounding001, MidpointRounding.AwayFromZero},

                new object[] { 1.005m, 1m, RoundingType.Rounding005Down, MidpointRounding.AwayFromZero},
                new object[] { 1.004m, 1m, RoundingType.Rounding005Down, MidpointRounding.AwayFromZero},
                new object[] { 1.009m, 1m, RoundingType.Rounding005Down, MidpointRounding.AwayFromZero},

                new object[] { 1.005m, 1.05m, RoundingType.Rounding005Up, MidpointRounding.AwayFromZero},
                new object[] { 1.095m, 1.1m, RoundingType.Rounding005Up, MidpointRounding.AwayFromZero},
                new object[] { 1.5m, 1.5m, RoundingType.Rounding005Up, MidpointRounding.AwayFromZero},

                new object[] { 1.105m, 1.1m, RoundingType.Rounding01Down, MidpointRounding.AwayFromZero},
                new object[] { 1.599m, 1.6m, RoundingType.Rounding01Down, MidpointRounding.AwayFromZero},
                new object[] { 1.999m, 2m, RoundingType.Rounding01Down, MidpointRounding.AwayFromZero},

                new object[] { 1.09m, 1.1m, RoundingType.Rounding01Up, MidpointRounding.AwayFromZero},

                new object[] { 1.04m, 1m, RoundingType.Rounding05, MidpointRounding.AwayFromZero},
                new object[] { 1.400009m, 1.5m, RoundingType.Rounding05, MidpointRounding.AwayFromZero},

                new object[] { 1.005m, 1m, RoundingType.Rounding1, MidpointRounding.AwayFromZero},
                new object[] { 1.6m, 2m, RoundingType.Rounding1, MidpointRounding.AwayFromZero},
                new object[] { 1.5m, 2m, RoundingType.Rounding1, MidpointRounding.AwayFromZero},

                new object[] { 1.009m, 2m, RoundingType.Rounding1Up, MidpointRounding.AwayFromZero},

                // To Even
                new object[] { 1.005m, 1m, RoundingType.Rounding001, MidpointRounding.ToEven},
                new object[] { 1.004m, 1m, RoundingType.Rounding001, MidpointRounding.ToEven},
                new object[] { 1.0009m, 1m, RoundingType.Rounding001, MidpointRounding.ToEven},

                new object[] { 1.005m, 1m, RoundingType.Rounding005Down, MidpointRounding.ToEven},
                new object[] { 1.004m, 1m, RoundingType.Rounding005Down, MidpointRounding.ToEven},
                new object[] { 1.009m, 1m, RoundingType.Rounding005Down, MidpointRounding.ToEven},

                new object[] { 1.005m, 1m, RoundingType.Rounding005Up, MidpointRounding.ToEven},
                new object[] { 1.095m, 1.1m, RoundingType.Rounding005Up, MidpointRounding.ToEven},
                new object[] { 1.5m, 1.5m, RoundingType.Rounding005Up, MidpointRounding.ToEven},

                new object[] { 1.105m, 1.1m, RoundingType.Rounding01Down, MidpointRounding.ToEven},
                new object[] { 1.599m, 1.6m, RoundingType.Rounding01Down, MidpointRounding.ToEven},
                new object[] { 1.999m, 2m, RoundingType.Rounding01Down, MidpointRounding.ToEven},

                new object[] { 1.09m, 1.1m, RoundingType.Rounding01Up, MidpointRounding.ToEven},

                new object[] { 1.04m, 1m, RoundingType.Rounding05, MidpointRounding.ToEven},
                new object[] { 1.400009m, 1.5m, RoundingType.Rounding05, MidpointRounding.ToEven},

                new object[] { 1.005m, 1m, RoundingType.Rounding1, MidpointRounding.ToEven},
                new object[] { 1.6m, 2m, RoundingType.Rounding1, MidpointRounding.ToEven},
                new object[] { 1.5m, 2m, RoundingType.Rounding1, MidpointRounding.ToEven},

                new object[] { 1.009m, 2m, RoundingType.Rounding1Up, MidpointRounding.ToEven},
            };
    }
}
