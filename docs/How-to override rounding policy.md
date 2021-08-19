# How-to extend rounding policy
## 1. Implement the intefrace VirtoCommerce.CoreModule.Core.Currency.IMoneyRoundingPolicy
```csharp
public class CustomMoneyRoundingPolicy : IMoneyRoundingPolicy
{
    public decimal RoundMoney(decimal amount, Currency currency)
    {
        // Some rounding logic
    }
}
```
## 2. Register it with the DI container in Module.cs
```csharp
public void Initialize(IServiceCollection serviceCollection)
{
    ... 

    // Money rounding
    serviceCollection.AddTransient<IMoneyRoundingPolicy, CustomMoneyRoundingPolicy>();
}
```
