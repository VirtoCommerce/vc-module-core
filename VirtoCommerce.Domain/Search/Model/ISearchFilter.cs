using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface ISearchFilter
    {
        string Key { get; }

        string CacheKey { get; }
    }
}
