using System;

namespace VirtoCommerce.Domain.Search.Services
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface ISearchIndexController
    {
        void Process(string scope, string documentType, bool rebuild);
    }
}
