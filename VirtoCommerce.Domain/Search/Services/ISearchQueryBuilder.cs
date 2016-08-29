using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Domain.Search.Model;

namespace VirtoCommerce.Domain.Search.Services
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface ISearchQueryBuilder
    {
        object BuildQuery(ISearchCriteria criteria);
    }

}
