using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public static class IndexStore
    {
        /// <summary>
        /// Values are stored in the index
        /// </summary>
        public const string Yes = "Store.Yes";
        /// <summary>
        /// Values are not stored
        /// </summary>
        public const string No = "Store.No";
    }
}
