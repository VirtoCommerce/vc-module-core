namespace VirtoCommerce.CoreModule.Core.Currency
{
    public interface IMoneyRoundingPolicy
    {
        decimal RoundMoney(decimal amount, Currency currency);
    }
}
