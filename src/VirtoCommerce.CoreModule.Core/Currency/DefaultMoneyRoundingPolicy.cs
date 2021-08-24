using System;
using VirtoCommerce.CoreModule.Core.Enums;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Currency
{
    // TODO: Reduce the cognitive complexity
    // https://github.com/grandnode/grandnode2/blob/master/src/Business/Grand.Business.Catalog/Extensions/RoundingHelper.cs#L44
    public class DefaultMoneyRoundingPolicy : IMoneyRoundingPolicy
    {
        public decimal RoundMoney(decimal amount, Currency currency)
        {
            var roundingType = EnumUtility.SafeParse(currency.RoundingType, RoundingType.Rounding001);
            var midpointRounding = EnumUtility.SafeParse(currency.MidpointRounding, MidpointRounding.AwayFromZero);
            return Round(amount, currency.NumberFormat.NumberDecimalDigits, roundingType, midpointRounding);
        }

        /// <summary>
        /// Round
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="decimals">Number of digits in fractional part</param>
        /// <param name="roundingType">The rounding type</param>
        /// <param name="midpointRounding">Specifies how mathematical rounding methods should process a number that is midway between two numbers</param>
        /// <returns>Rounded value</returns>
        protected decimal Round(decimal value, int decimals, RoundingType roundingType, MidpointRounding midpointRounding)
        {
            //default round (Rounding001)
            var result = Math.Round(value, decimals, midpointRounding);
            var fractionPart = (result - Math.Truncate(result)) * 10;

            //cash rounding not needed
            if (fractionPart == 0)
                return result;

            //Cash rounding (details: https://en.wikipedia.org/wiki/Cash_rounding)
            switch (roundingType)
            {
                //rounding with 0.05 or 5 intervals
                case RoundingType.Rounding005Up:
                case RoundingType.Rounding005Down:
                    fractionPart = (fractionPart - Math.Truncate(fractionPart)) * 10;
                    if (fractionPart == 5 || fractionPart == 0)
                        break;
                    if (roundingType == RoundingType.Rounding005Down)
                        fractionPart = fractionPart > 5 ? 5 - fractionPart : fractionPart * -1;
                    else
                        fractionPart = fractionPart > 5 ? 10 - fractionPart : 5 - fractionPart;

                    result += fractionPart / 100;
                    break;
                //rounding with 0.10 intervals
                case RoundingType.Rounding01Up:
                case RoundingType.Rounding01Down:
                    fractionPart = (fractionPart - Math.Truncate(fractionPart)) * 10;
                    if (fractionPart == 0)
                        break;

                    if (roundingType == RoundingType.Rounding01Down && fractionPart == 5)
                        fractionPart = -5;
                    else if (roundingType == RoundingType.Rounding01Up)
                        fractionPart = 10 - fractionPart;
                    else if (roundingType == RoundingType.Rounding01Down)
                        fractionPart = fractionPart * -1;
                    result += fractionPart / 100;
                    break;
                //rounding with 0.50 intervals
                case RoundingType.Rounding05:
                    fractionPart *= 10;
                    fractionPart = fractionPart < 25 ? fractionPart * -1 : fractionPart < 50 || fractionPart < 75 ? 50 - fractionPart : 100 - fractionPart;

                    result += fractionPart / 100;
                    break;
                //rounding with 1.00 intervals
                case RoundingType.Rounding1:
                case RoundingType.Rounding1Up:
                    fractionPart *= 10;

                    if (roundingType == RoundingType.Rounding1Up && fractionPart > 0)
                        result = Math.Truncate(result) + 1;
                    else
                        result = fractionPart < 50 ? Math.Truncate(result) : Math.Truncate(result) + 1;

                    break;

                case RoundingType.Rounding001:
                default:
                    break;
            }

            return result;
        }
    }
}
