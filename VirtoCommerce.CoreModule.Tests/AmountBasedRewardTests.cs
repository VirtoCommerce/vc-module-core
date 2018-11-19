using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Marketing.Model;
using Xunit;
using Xunit.Extensions;

namespace VirtoCommerce.CoreModule.Tests
{
    [Trait("Category", "CI")]
    public class AmountBasedRewardTests
    {
        [CLSCompliant(false)]
        [Theory]
        [MemberData(nameof(TestRewards))]
        public virtual void TestGetRewardAmounts(AmountBasedReward reward, decimal price, int qty, decimal expectedResult)
        {
            Assert.Equal(reward.GetRewardAmount(price, qty), expectedResult);
        }


        public static IEnumerable<object[]> TestRewards
        {
            get
            {
                //For 2 out of 3 items with price $100.0 get %50 off  =  Get $9.99 discount per item
                yield return new object[] { new CatalogItemAmountReward { Amount = 50.0m, AmountType = RewardAmountType.Relative, Quantity = 2 }, 100.0m, 3, 33.34m };

                //Border parameters.
                //For 10 items with price $1.0 get $100 off not to exceed $100 = $1.0 discount per item
                yield return new object[] { new CatalogItemAmountReward { Amount = 100m, AmountType = RewardAmountType.Absolute, MaxLimit = 100 }, 1.0m, 10, 1.0m };
                //For 0 items with price $1.0 get $100 off =  Get  $1.0 discount per item
                yield return new object[] { new CatalogItemAmountReward { Amount = 100m, AmountType = RewardAmountType.Absolute }, 1.0m, 0, 1.0m };
                //For 0 items with price $0.0 get $100 off =  Get  $0.0 discount per item 
                yield return new object[] { new CatalogItemAmountReward { Amount = 100.0m, AmountType = RewardAmountType.Absolute }, 0m, 0, 0m };
                //For 1 item  with price $1.0 get $0 off  =  Get $0.0 discount per item 
                yield return new object[] { new CatalogItemAmountReward { Amount = 0m, AmountType = RewardAmountType.Absolute }, 1.0m, 1, 0m };



                //For 10 items with price $9.99 get $10 off  =  Get $9.99 discount per item
                yield return new object[] { new CatalogItemAmountReward { Amount = 10.0m, AmountType = RewardAmountType.Absolute }, 9.99m, 10, 9.99m };
                //For 3 out of 10 items with price $99.99 get %13.5 off  =  Get  40.05 discount per item
                yield return new object[] { new CatalogItemAmountReward { Quantity = 3, Amount = 13.5m, AmountType = RewardAmountType.Relative }, 99.99m, 10, 4.05m };
                //For 15 items with price $100.0  get % 50 off =  Get  $50.0 discount per item
                yield return new object[] { new CatalogItemAmountReward { Amount = 50, AmountType = RewardAmountType.Relative }, 100.0m, 15, 50.0m };
                //For 2 in every 3 items of entry  get %50 off limit 4 items not to exceed $150 = Get $15.0 discount per item
                yield return new object[] { new CatalogItemAmountReward { ForNthQuantity = 2, InEveryNthQuantity = 3, MaxLimit = 150, Quantity = 4, Amount = 50, AmountType = RewardAmountType.Relative }, 100.0m, 10, 15.0m };
            }
        }
    }
}
