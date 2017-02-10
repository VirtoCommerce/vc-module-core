using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Domain.Marketing.Model.DynamicContent.Search;

namespace VirtoCommerce.Domain.Marketing.Services
{
    public interface IDynamicContentSearchService
    {
        GenericSearchResult<DynamicContentFolder> SearchFolders(DynamicContentFolderSearchCriteria criteria);
        GenericSearchResult<DynamicContentItem> SearchContentItems(DynamicContentItemSearchCriteria criteria);
        GenericSearchResult<DynamicContentPlace> SearchContentPlaces(DynamicContentPlaceSearchCriteria criteria);
        GenericSearchResult<DynamicContentPublication> SearchContentPublications(DynamicContentPublicationSearchCriteria criteria);
    }
}
