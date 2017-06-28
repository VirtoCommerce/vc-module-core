using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Customer.Model.Search;

namespace VirtoCommerce.Domain.Customer.Services
{
    public interface IMemberSearchService
    {
        GenericSearchResult<Member> SearchMembers(MemberSearchCriteria criteria);
    }
}
