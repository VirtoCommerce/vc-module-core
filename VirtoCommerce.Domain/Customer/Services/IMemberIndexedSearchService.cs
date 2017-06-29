using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.Domain.Customer.Services
{
    public interface IMemberIndexedSearchService : IIndexedSearchService<Member, MembersSearchCriteria>
    {
    }
}
