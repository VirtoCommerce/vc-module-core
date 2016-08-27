using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public static class IndexType
    {
        /// <summary>
        /// Values are parsed to tokens
        /// </summary>
        public const string Analyzed = "Index.Analyzed";
        /// <summary>
        /// Values are indexed as is
        /// </summary>
        public const string NotAnalyzed = "Index.NotAnalyzed";
        /// <summary>
        /// Values are not indexed
        /// </summary>
        public const string No = "Index.No";
    }
}
