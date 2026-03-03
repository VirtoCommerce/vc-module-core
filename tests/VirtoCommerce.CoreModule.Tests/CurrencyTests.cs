using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Core.Currency;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests
{
    public class CurrencyTests
    {
        [Theory]
        [InlineData("en-US", "USD", "US Dollar")]
        [InlineData("en-US", "EUR", "Euro")]
        [InlineData("en-US", "GBP", "British Pound")]
        [InlineData("de-DE", "USD", "US Dollar")]
        [InlineData("de-DE", "EUR", "Euro")]
        [InlineData("fr-FR", "GBP", "British Pound")]
        public void Currency_EnglishName_ShouldMatchCurrencyCode_NotLanguage(string cultureName, string currencyCode, string expectedEnglishName)
        {
            // Arrange & Act
            var currency = new Currency(new Language(cultureName), currencyCode);

            // Assert
            Assert.Equal(expectedEnglishName, currency.EnglishName);
        }

        [Fact]
        public void Currency_EnglishName_ShouldBeOverriddenByExplicitName()
        {
            // Arrange
            var customName = "Custom Currency Name";

            // Act
            var currency = new Currency(new Language("en-US"), "EUR", customName, "€", 1.0m);

            // Assert
            Assert.Equal(customName, currency.EnglishName);
        }

        [Fact]
        public void Currency_EnglishName_ShouldFallbackToCodeBased_WhenExplicitNameIsEmpty()
        {
            // Arrange & Act
            var currency = new Currency(new Language("en-US"), "EUR", null, "€", 1.0m);

            // Assert
            Assert.Equal("Euro", currency.EnglishName);
        }

        [Theory]
        [InlineData("Miles")]
        [InlineData("Points")]
        [InlineData("Tokens")]
        public void Currency_EnglishName_ShouldBeEmpty_ForNonIsoCurrencyCode(string currencyCode)
        {
            // Arrange & Act
            var currency = new Currency(new Language("en-US"), currencyCode);

            // Assert
            Assert.Equal(string.Empty, currency.EnglishName);
        }

        [Fact]
        public void Currency_SetCultureName_ShouldPreserveCorrectEnglishName()
        {
            // Arrange
            var currency = new Currency(new Language("en-US"), "EUR");
            Assert.Equal("Euro", currency.EnglishName);

            // Act - changing culture should not change the currency english name
            currency.CultureName = "de-DE";

            // Assert
            Assert.Equal("Euro", currency.EnglishName);
        }
    }
}
