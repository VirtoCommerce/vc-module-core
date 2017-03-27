using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Domain.Marketing.Model.Promotions.Search;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface IPromotionUsageService
    {
        GenericSearchResult<PromotionUsage> SearchUsages(PromotionUsageSearchCriteria criteria);

        PromotionUsage[] GetByIds(string[] ids);
        void SaveUsages(PromotionUsage[] usages);
        void DeleteUsages(string[] ids);
    }
}
