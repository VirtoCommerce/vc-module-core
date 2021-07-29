using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Currency
{
    /// <summary>
    /// Currency
    /// </summary>
    public class Currency : ValueObject
    {
        private static IDictionary<string, string> _isoCurrencySymbolDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase).WithDefaultValue(null);
        private Language _language;
        private string _code;

        static Currency()
        {
            foreach (var ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                try
                {
                    var ri = new RegionInfo(ci.LCID);
                    _isoCurrencySymbolDict[ri.ISOCurrencySymbol] = ri.CurrencySymbol;
                }
                catch (Exception)
                {
                    // No need to catch
                }
            }
        }

        public Currency(Language language, string code, string name, string symbol, decimal exchangeRate)
             : this(language, code)
        {
            ExchangeRate = exchangeRate;

            if (!string.IsNullOrEmpty(name))
            {
                EnglishName = name;
            }

            if (!string.IsNullOrEmpty(symbol))
            {
                Symbol = symbol;
                NumberFormat.CurrencySymbol = symbol;
            }
        }

        public Currency(Language language, string code)
        {
            _language = language;
            _code = code;
            ExchangeRate = 1;
            Initialize();
        }

        public Currency()
            : this(Language.InvariantLanguage, null)
        {
        }

        /// <summary>
        /// Currency code may be used ISO 4217.
        /// </summary>
        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                Initialize();
            }
        }

        public string CultureName
        {
            get => _language?.CultureName;
            set
            {
                _language = new Language(value);
                Initialize();
            }
        }

        public string EnglishName { get; set; }

        [JsonIgnore]
        public NumberFormatInfo NumberFormat { get; private set; }

        /// <summary>
        ///  name of the currency
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag specifies that this is the primary currency
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// The exchange rate against the primary exchange rate of the currency.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Currency symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Custom formatting pattern
        /// </summary>
        public string CustomFormatting { get; set; }

        [JsonIgnore]
        public IMoneyRoundingPolicy RoundingPolicy { get; set; }

        public RoundingType RoundingType { get; set; } = RoundingType.Rounding001;
        public MidpointRounding MidpointRounding { get; set; } = MidpointRounding.AwayFromZero;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return CultureName;
        }

        private void Initialize()
        {
            if (_language is null)
            {
                return;
            }

            if (!_language.IsInvariant)
            {
                var cultureInfo = CultureInfo.GetCultureInfo(_language.CultureName);
                NumberFormat = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
                EnglishName = cultureInfo.NumberFormat.CurrencySymbol;

                if (!cultureInfo.IsNeutralCulture && cultureInfo != CultureInfo.InvariantCulture)
                {
                    var region = new RegionInfo(_language.CultureName);
                    EnglishName = region.CurrencyEnglishName;
                }

                if (_code != null)
                {
                    Symbol = _isoCurrencySymbolDict[_code] ?? "N/A";
                    NumberFormat.CurrencySymbol = Symbol;
                }
            }
            else
            {
                NumberFormat = CultureInfo.InvariantCulture.NumberFormat.Clone() as NumberFormatInfo;
            }
        }
    }
}
