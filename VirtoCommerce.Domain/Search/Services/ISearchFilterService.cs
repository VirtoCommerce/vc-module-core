using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Search.Model;

namespace VirtoCommerce.Domain.Search.Services
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface IBrowseFilterService
    {
        ISearchFilter[] GetFilters(IDictionary<string, object> context);
    }
}
