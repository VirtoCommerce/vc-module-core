using System;
using System.Collections.Generic;
using System.Text;

namespace VirtoCommerce.CoreModule.Core.Currency
{
    public interface IMoneyRoundingPolicy
    {
        decimal RoundMoney(decimal amount, Currency currency);
    }
}
