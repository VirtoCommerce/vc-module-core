using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexedSearchService<TItem, in TCriteria>
        where TItem : Entity
        where TCriteria : SearchCriteriaBase
    {
        Task<GenericSearchResult<TItem>> SearchAsync(TCriteria criteria);
    }
}
